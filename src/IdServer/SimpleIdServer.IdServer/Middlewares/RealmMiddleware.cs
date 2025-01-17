﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimpleIdServer.IdServer.Options;
using SimpleIdServer.IdServer.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleIdServer.IdServer.Middlewares
{
    public class RealmMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RealmMiddleware> _logger;
        private readonly IdServerHostOptions _options;
        private readonly IServiceProvider _serviceProvider;

        public RealmMiddleware(RequestDelegate next, ILogger<RealmMiddleware> logger, IOptions<IdServerHostOptions> options, IServiceProvider serviceProvider)
        {
            _next = next;
            _logger = logger;
            _options = options.Value;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            RealmContext.Instance().Realm = null;
            if (_options.UseRealm)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var realmRepository = scope.ServiceProvider.GetRequiredService<IRealmRepository>();
                    var routeValues = context.Request.RouteValues;
                    string realm = string.Empty;
                    var realmCookie = context.Request.Cookies.FirstOrDefault(c => c.Key == Constants.DefaultRealmCookieName);
                    if (routeValues.ContainsKey(Constants.Prefix))
                    {
                        var prefix = routeValues.First(v => v.Key == Constants.Prefix).Value?.ToString();
                        if (realmCookie.Value != prefix)
                        {
                            if (await realmRepository.Query().AnyAsync(r => r.Name == prefix))
                            {
                                realm = prefix;
                                if (!string.IsNullOrWhiteSpace(realm))
                                {
                                    context.Response.Cookies.Append(
                                        Constants.DefaultRealmCookieName,
                                        realm);
                                }
                            }
                        }
                        else
                            realm = prefix;
                    }

                    if (string.IsNullOrWhiteSpace(realm) && !realmCookie.Equals(default(KeyValuePair<string, string>)) && !string.IsNullOrWhiteSpace(realmCookie.Value))
                        realm = realmCookie.Value;

                    RealmContext.Instance().Realm = realm;
                }
            }

            await _next.Invoke(context);
        }
    }
}
