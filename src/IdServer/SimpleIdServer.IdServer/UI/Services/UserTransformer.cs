﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.IdentityModel.JsonWebTokens;
using SimpleIdServer.IdServer.Domains;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SimpleIdServer.IdServer.UI.Services
{
    public interface IUserTransformer
    {
        User Transform(ClaimsPrincipal principal);
        ICollection<Claim> Transform(User user);
    }

    public class UserTransformer : IUserTransformer
    {
        private static Dictionary<string, string> CLAIM_MAPPINGS = new Dictionary<string, string>
        {
            { ClaimTypes.NameIdentifier, JwtRegisteredClaimNames.Sub },
            { ClaimTypes.Name, JwtRegisteredClaimNames.Name },
            { ClaimTypes.Email, JwtRegisteredClaimNames.Email },
            { ClaimTypes.DateOfBirth, JwtRegisteredClaimNames.Birthdate },
            { ClaimTypes.Gender, JwtRegisteredClaimNames.Gender },
            { ClaimTypes.GivenName, JwtRegisteredClaimNames.GivenName }
        };

        public User Transform(ClaimsPrincipal principal)
        {
            var claims = principal.Claims.Select(u => new UserClaim
            {
                Name = u.Type,
                Value = u.Value
            }).ToList();
            var sub = claims.Single(c => c.Name == ClaimTypes.NameIdentifier);
            var user = User.Create(sub.Value);
            user.UpdateClaims(claims.Select(c =>
            {
                if (CLAIM_MAPPINGS.ContainsKey(c.Name))
                    c.Name = CLAIM_MAPPINGS[c.Name];
                return c;
            }).ToList());
            return user;
        }

        public ICollection<Claim> Transform(User user)
        {
            var result = new List<Claim>();
            foreach(var cl in user.Claims)
            {
                var cm = CLAIM_MAPPINGS.FirstOrDefault(c => c.Value == cl.Type);
                if (!cm.Equals(default(KeyValuePair<string, string>)) && cm.Value != null)
                    result.Add(new Claim(cm.Key, cl.Value));
                else result.Add(cl);
            }

            return result;
        }
    }
}