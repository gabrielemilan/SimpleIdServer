﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Fluxor;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SimpleIdServer.IdServer.Domains;
using SimpleIdServer.IdServer.Store;
using SimpleIdServer.IdServer.Website.Resources;
using System.Linq.Dynamic.Core;

namespace SimpleIdServer.IdServer.Website.Stores.IdentityProvisioningStore
{
    public class IdentityProvisioningEffects
    {
        private readonly IIdentityProvisioningStore _identityProvisioningStore;
        private readonly IdServerWebsiteOptions _options;
        private readonly ProtectedSessionStorage _sessionStorage;

        public IdentityProvisioningEffects(IIdentityProvisioningStore identityProvisioningStore, IOptions<IdServerWebsiteOptions> options, ProtectedSessionStorage sessionStorage)
        {
            _identityProvisioningStore = identityProvisioningStore;
            _options = options.Value;
            _sessionStorage = sessionStorage;
        }

        [EffectMethod]
        public async Task Handle(SearchIdentityProvisioningAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            IQueryable<IdentityProvisioning> query = _identityProvisioningStore.Query().Include(c => c.Realms).Where(c => c.Realms.Any(r => r.Name == realm)).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(action.Filter))
                query = query.Where(SanitizeExpression(action.Filter));

            if (!string.IsNullOrWhiteSpace(action.OrderBy))
                query = query.OrderBy(SanitizeExpression(action.OrderBy));

            var nb = query.Count();
            var identityProvisioningLst = await query.Skip(action.Skip.Value).Take(action.Take.Value).ToListAsync(CancellationToken.None);
            dispatcher.Dispatch(new SearchIdentityProvisioningSuccessAction { IdentityProvisioningLst = identityProvisioningLst, Count = nb });

            string SanitizeExpression(string expression) => expression.Replace("Value.", "");
        }

        [EffectMethod]
        public async Task Handle(RemoveSelectedIdentityProvisioningAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            var toBeRemoved = await _identityProvisioningStore.Query().Include(c => c.Realms).Where(c => c.Realms.Any(r => r.Name == realm) && action.Ids.Contains(c.Id)).ToListAsync();
            _identityProvisioningStore.DeleteRange(toBeRemoved);
            await _identityProvisioningStore.SaveChanges(CancellationToken.None);
            dispatcher.Dispatch(new RemoveSelectedIdentityProvisioningSuccessAction { Ids = action.Ids });
        }

        [EffectMethod]
        public async Task Handle(GetIdentityProvisioningAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            var result = await _identityProvisioningStore.Query().Include(c => c.Realms)
                .Include(c => c.Properties)
                .Include(c => c.Definition).ThenInclude(d => d.Properties)
                .Include(c => c.Definition).ThenInclude(d => d.MappingRules)
                .Include(c => c.Histories)
                .SingleOrDefaultAsync(c => c.Realms.Any(r => r.Name == realm) && action.Id == c.Id);
            if(result == null)
            {
                dispatcher.Dispatch(new GetIdentityProvisioningFailureAction { ErrorMessage = Global.UnknownIdentityProvisioning });
                return;
            }

            dispatcher.Dispatch(new GetIdentityProvisioningSuccessAction { IdentityProvisioning = result });
        }

        [EffectMethod]
        public async Task Handle(LaunchIdentityProvisioningAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            using (var httpClient = new HttpClient(handler))
            {
                var requestMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri($"{_options.IdServerBaseUrl}/{realm}/provisioning/{action.Name}/{action.Id}/enqueue")
                };
                await httpClient.SendAsync(requestMessage);
            }

            dispatcher.Dispatch(new LaunchIdentityProvisioningSuccessAction { Id = action.Id, Name = action.Name });
        }

        [EffectMethod]
        public async Task Handle(UpdateIdProvisioningPropertiesAction action, IDispatcher dispatcher)
        {
            var result = await _identityProvisioningStore.Query().Include(p => p.Properties).SingleAsync(i => i.Id == action.Id);
            result.Properties.Clear();
            foreach(var property in action.Properties)
                result.Properties.Add(property);

            await _identityProvisioningStore.SaveChanges(CancellationToken.None);
            dispatcher.Dispatch(new UpdateIdProvisioningPropertiesSuccessAction { Id = action.Id, Properties = action.Properties });
        }

        [EffectMethod]
        public async Task Handle(UpdateIdProvisioningDetailsAction action, IDispatcher dispatcher)
        {
            var result = await _identityProvisioningStore.Query().SingleAsync(i => i.Id == action.Id);
            result.Description = action.Description;
            await _identityProvisioningStore.SaveChanges(CancellationToken.None);
            dispatcher.Dispatch(new UpdateIdProvisioningDetailsSuccessAction { Description = action.Description, Id = action.Id });
        }

        [EffectMethod]
        public async Task Handle(RemoveSelectedIdentityProvisioningMappingRulesAction action, IDispatcher dispatcher)
        {
            var result = await _identityProvisioningStore.Query().Include(i => i.Definition).ThenInclude(d => d.MappingRules).SingleAsync(i => i.Id == action.Id);
            var mappingRules = result.Definition.MappingRules;
            result.Definition.MappingRules = result.Definition.MappingRules.Where(r => !action.MappingRuleIds.Contains(r.Id)).ToList();
            await _identityProvisioningStore.SaveChanges(CancellationToken.None);
            dispatcher.Dispatch(new RemoveSelectedIdentityProvisioningMappingRulesSuccessAction { Id = action.Id, MappingRuleIds = action.MappingRuleIds });
        }

        [EffectMethod]
        public async Task Handle(AddIdentityProvisioningMappingRuleAction action, IDispatcher dispatcher)
        {
            var result = await _identityProvisioningStore.Query().Include(i => i.Definition).ThenInclude(d => d.MappingRules).SingleAsync(i => i.Id == action.Id);
            var mappingRules = result.Definition.MappingRules;
            var newId = Guid.NewGuid().ToString();
            mappingRules.Add(new IdentityProvisioningMappingRule
            {
                From= action.From,
                Id = newId,
                MapperType = action.MappingRule,
                TargetUserAttribute = action.TargetUserAttribute,
                TargetUserProperty = action.TargetUserProperty
            });
            await _identityProvisioningStore.SaveChanges(CancellationToken.None);
            dispatcher.Dispatch(new AddIdentityProvisioningMappingRuleSuccessAction { NewId = newId, Id = action.Id, MappingRule = action.MappingRule, From = action.From, TargetUserAttribute = action.TargetUserAttribute, TargetUserProperty = action.TargetUserProperty });
        }

        private async Task<string> GetRealm()
        {
            var realm = await _sessionStorage.GetAsync<string>("realm");
            var realmStr = !string.IsNullOrWhiteSpace(realm.Value) ? realm.Value : SimpleIdServer.IdServer.Constants.DefaultRealm;
            return realmStr;
        }
    }

    public class SearchIdentityProvisioningAction
    {
        public string? Filter { get; set; } = null;
        public string? OrderBy { get; set; } = null;
        public int? Skip { get; set; } = null;
        public int? Take { get; set; } = null;
    }

    public class SearchIdentityProvisioningSuccessAction
    {
        public IEnumerable<IdentityProvisioning> IdentityProvisioningLst { get; set; }
        public int Count { get; set; }
    }

    public class GetIdentityProvisioningAction
    {
        public string Id { get; set; }
    }

    public class GetIdentityProvisioningFailureAction
    {
        public string ErrorMessage { get; set; }
    }

    public class GetIdentityProvisioningSuccessAction
    {
        public IdentityProvisioning IdentityProvisioning { get; set; }
    }

    public class ToggleAllIdentityProvisioningAction
    {
        public bool IsSelected { get; set; }
    }

    public class ToggleIdentityProvisioningSelectionAction
    {
        public bool IsSelected { get; set; }
        public string IdentityProvisioningId { get; set; }
    }

    public class RemoveSelectedIdentityProvisioningAction
    {
        public IEnumerable<string> Ids { get; set; }
    }

    public class RemoveSelectedIdentityProvisioningSuccessAction
    {
        public IEnumerable<string> Ids { get; set; }
    }

    public class LaunchIdentityProvisioningAction
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class LaunchIdentityProvisioningSuccessAction
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateIdProvisioningPropertiesAction
    {
        public string Id { get; set; }
        public IEnumerable<IdentityProvisioningProperty> Properties { get; set; }
    }

    public class UpdateIdProvisioningPropertiesSuccessAction
    {
        public string Id { get; set; }
        public IEnumerable<IdentityProvisioningProperty> Properties { get; set; }
    }

    public class UpdateIdProvisioningDetailsAction
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }

    public class UpdateIdProvisioningDetailsSuccessAction
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }

    public class SelectIdentityProvisioningMappingRuleAction
    {
        public bool IsSelected { get; set; }
        public string Id { get; set; }
    }

    public class SelectAllIdentityProvisioningMappingRulesAction
    {
        public bool IsSelected { get; set; }
    }

    public class RemoveSelectedIdentityProvisioningMappingRulesAction
    {
        public IEnumerable<string> MappingRuleIds { get; set; }
        public string Id { get; set; }
    }

    public class RemoveSelectedIdentityProvisioningMappingRulesSuccessAction
    {
        public IEnumerable<string> MappingRuleIds { get; set; }
        public string Id { get; set; }
    }

    public class AddIdentityProvisioningMappingRuleAction
    {
        public string Id { get; set; }
        public MappingRuleTypes MappingRule { get; set; }
        public string From { get; set; } = null!;
        public string? TargetUserAttribute { get; set; } = null;
        public string? TargetUserProperty { get; set; } = null;
    }

    public class AddIdentityProvisioningMappingRuleSuccessAction
    {
        public string Id { get; set; }
        public string NewId { get; set; }
        public MappingRuleTypes MappingRule { get; set; }
        public string From { get; set; } = null!;
        public string? TargetUserAttribute { get; set; } = null;
        public string? TargetUserProperty { get; set; } = null;
    }
}
