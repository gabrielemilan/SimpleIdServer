﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using SimpleIdServer.IdServer.Domains;
using SimpleIdServer.IdServer.UI.AuthProviders;
using System;
using System.Text.Json;

namespace SimpleIdServer.IdServer.Builders
{
    public class AuthenticationSchemeProviderBuilder
    {
        private AuthenticationSchemeProvider _provider;

        private AuthenticationSchemeProviderBuilder(AuthenticationSchemeProvider provider) 
        {
            _provider = provider;
        }

        public static AuthenticationSchemeProviderBuilder Create<TOpts>(string name, string displayName, Type handlerType, IDynamicAuthenticationOptions<TOpts> options) where TOpts : Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions, new()
        {
            return new AuthenticationSchemeProviderBuilder(new AuthenticationSchemeProvider
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                DisplayName = displayName,
                CreateDateTime = DateTime.UtcNow,
                UpdateDateTime = DateTime.UtcNow,
                IsEnabled = true,
                HandlerFullQualifiedName = handlerType.AssemblyQualifiedName,
                OptionsFullQualifiedName = options.GetType().AssemblyQualifiedName,
                SerializedOptions = JsonSerializer.Serialize(options, options.GetType())
            });
        }

        public AuthenticationSchemeProvider Build() => _provider;
    }
}