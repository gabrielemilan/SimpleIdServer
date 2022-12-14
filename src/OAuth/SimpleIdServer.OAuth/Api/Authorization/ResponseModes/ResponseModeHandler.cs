﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.AspNetCore.Http;
using SimpleIdServer.OAuth.Api.Authorization.ResponseTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;

namespace SimpleIdServer.OAuth.Api.Authorization.ResponseModes
{
    public class ResponseModeHandler : IResponseModeHandler
    {
        private readonly IEnumerable<IOAuthResponseModeHandler> _oauthResponseModeHandlers;

        public ResponseModeHandler(IEnumerable<IOAuthResponseModeHandler> oauthResponseModeHandlers)
        {
            _oauthResponseModeHandlers = oauthResponseModeHandlers;
        }

        public void Handle(JsonObject queryParams, RedirectURLAuthorizationResponse authorizationResponse, HttpContext httpContext)
        {
            var responseTypes = queryParams.GetResponseTypesFromAuthorizationRequest();
            var responseMode = queryParams.GetResponseModeFromAuthorizationRequest();
            IOAuthResponseModeHandler oauthResponseModeHandler = null;
            if (!string.IsNullOrWhiteSpace(responseMode))
            {
                oauthResponseModeHandler = _oauthResponseModeHandlers.FirstOrDefault(o => o.ResponseMode == responseMode);
                if (oauthResponseModeHandler == null)
                {
                    responseMode = null;
                }
            }

            if (string.IsNullOrWhiteSpace(responseMode))
            {
                responseMode = GetDefaultResponseMode(responseTypes);
            }

            oauthResponseModeHandler = _oauthResponseModeHandlers.FirstOrDefault(o => o.ResponseMode == responseMode);
            if (oauthResponseModeHandler == null)
            {
                oauthResponseModeHandler = _oauthResponseModeHandlers.First(o => o.ResponseMode == QueryResponseModeHandler.NAME);
            }

            oauthResponseModeHandler.Handle(authorizationResponse, httpContext);
        }

        protected virtual string GetDefaultResponseMode(IEnumerable<string> responseTypes)
        {
            var responseMode = string.Empty;
            // https://openid.net/specs/openid-connect-core-1_0.html#rfc.section.3.1.2.6
            if (!responseTypes.Any() || (responseTypes.Count() == 1 && responseTypes.Contains(AuthorizationCodeResponseTypeHandler.RESPONSE_TYPE)))
            {
                responseMode = QueryResponseModeHandler.NAME;
            }
            else
            {
                responseMode = FragmentResponseModeHandler.NAME;
            }

            return responseMode;
        }
    }
}