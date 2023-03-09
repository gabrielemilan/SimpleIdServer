﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SimpleIdServer.IdServer.Api.Authorization;
using SimpleIdServer.IdServer.Api.Authorization.ResponseTypes;
using SimpleIdServer.IdServer.Api.Token.Handlers;
using SimpleIdServer.IdServer.Authenticate;
using SimpleIdServer.IdServer.DTOs;
using SimpleIdServer.IdServer.Options;
using SimpleIdServer.IdServer.Store;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleIdServer.IdServer.Api.Configuration
{
    public interface IOAuthConfigurationRequestHandler
    {
        Task Enrich(string prefix, JsonObject jObj, string issuer, CancellationToken cancellationToken);
    }

    public class OAuthConfigurationRequestHandler : IOAuthConfigurationRequestHandler
    {
        private readonly IScopeRepository _scopeRepository;
        private readonly IEnumerable<IResponseTypeHandler> _authorizationGrantTypeHandlers;
        private readonly IEnumerable<IOAuthResponseMode> _oauthResponseModes;
        private readonly IEnumerable<IGrantTypeHandler> _grantTypeHandlers;
        private readonly IEnumerable<IOAuthClientAuthenticationHandler> _oauthClientAuthenticationHandlers;
        private readonly IOAuthWorkflowConverter _oauthWorkflowConverter;
        private readonly IdServerHostOptions _options;

        public OAuthConfigurationRequestHandler(
            IScopeRepository scopeRepository, 
            IEnumerable<IResponseTypeHandler> authorizationGrantTypeHandlers, 
            IEnumerable<IOAuthResponseMode> oauthResponseModes,
            IEnumerable<IGrantTypeHandler> grantTypeHandlers, 
            IEnumerable<IOAuthClientAuthenticationHandler> oauthClientAuthenticationHandlers,
            IOAuthWorkflowConverter oauthWorkflowConverter,
            IOptions<IdServerHostOptions> options)
        {
            _scopeRepository = scopeRepository;
            _authorizationGrantTypeHandlers = authorizationGrantTypeHandlers;
            _oauthResponseModes = oauthResponseModes;
            _grantTypeHandlers = grantTypeHandlers;
            _oauthClientAuthenticationHandlers = oauthClientAuthenticationHandlers;
            _oauthWorkflowConverter = oauthWorkflowConverter;
            _options = options.Value;
        }

        protected IOAuthWorkflowConverter WorkflowConverter => _oauthWorkflowConverter;

        public virtual async Task Enrich(string prefix, JsonObject jObj, string issuer, CancellationToken cancellationToken)
        {
            var realm = prefix ?? Constants.DefaultRealm;
            var scopes = await _scopeRepository.Query()
                .Include(s => s.Realms)
                .AsNoTracking()
                .Where(s => s.IsExposedInConfigurationEdp && s.Realms.Any(r => r.Name == realm))
                .Select(s => s.Name)
                .ToListAsync(cancellationToken);
            jObj.Add(OAuthConfigurationNames.TlsClientCertificateBoundAccessTokens, true);
            jObj.Add(OAuthConfigurationNames.ScopesSupported, JsonSerializer.SerializeToNode(scopes));
            jObj.Add(OAuthConfigurationNames.ResponseTypesSupported, JsonSerializer.SerializeToNode(GetResponseTypes()));
            jObj.Add(OAuthConfigurationNames.ResponseModesSupported, JsonSerializer.SerializeToNode(_oauthResponseModes.Select(s => s.ResponseMode)));
            jObj.Add(OAuthConfigurationNames.GrantTypesSupported, JsonSerializer.SerializeToNode(GetGrantTypes()));
            jObj.Add(OAuthConfigurationNames.TokenEndpointAuthMethodsSupported, JsonSerializer.SerializeToNode(_oauthClientAuthenticationHandlers.Select(r => r.AuthMethod)));
            jObj.Add(OAuthConfigurationNames.TokenEndpointAuthSigningAlgValuesSupported, JsonSerializer.SerializeToNode(Constants.AllSigningAlgs));
            if (_options.MtlsEnabled)
            {
                jObj.Add(OAuthConfigurationNames.MtlsEndpointAliases, new JsonObject
                {
                    [OAuthConfigurationNames.TokenEndpoint] = $"{issuer}/{Constants.EndPoints.MtlsToken}"
                });
            }
        }

        protected List<string> GetGrantTypes()
        {
            var result = new List<string>();
            result.AddRange(_grantTypeHandlers.Select(t => t.GrantType));
            result.AddRange(_authorizationGrantTypeHandlers.Select(t => t.GrantType));
            return result.Distinct().ToList();
        }

        protected List<string> GetResponseTypes()
        {
            var result = new List<string>();
            var responseTypes = _authorizationGrantTypeHandlers.Select(s => s.ResponseType).OrderBy(_ => _).Distinct();
            for (int i = 0; i < responseTypes.Count(); i++)
            {
                for (var y = 1; y <= responseTypes.Count() - i; y++)
                {
                    var responseTypeWorkflow = responseTypes.Skip(i).Take(y);
                    AddResponseTypes(responseTypeWorkflow);
                    if(responseTypeWorkflow.Count() > 1)
                        AddResponseTypes(new[] { responseTypeWorkflow.First(), responseTypeWorkflow.Last() });
                }
            }

            void AddResponseTypes(IEnumerable<string> responseTypeWorkflow)
            {
                if (_oauthWorkflowConverter.TryGetWorkflow(responseTypeWorkflow, out string workflowName))
                {
                    var record = string.Join(" ", responseTypeWorkflow.OrderBy(_ => _));
                    if (!result.Contains(record))
                    {
                        result.Add(record);
                    }
                }
            }

            return result;
        }
    }
}