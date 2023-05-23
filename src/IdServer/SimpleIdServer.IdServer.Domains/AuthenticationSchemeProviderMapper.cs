﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
namespace SimpleIdServer.IdServer.Domains
{
    public class AuthenticationSchemeProviderMapper : IProvisioningMappingRule
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? SourceClaimName { get; set; } = null;
        public MappingRuleTypes MapperType { get; set; }
        public string? TargetUserAttribute { get; set; } = null;
        public string? TargetUserProperty { get; set; } = null;
        public AuthenticationSchemeProvider IdProvider { get; set; } = null!;
    }
}
