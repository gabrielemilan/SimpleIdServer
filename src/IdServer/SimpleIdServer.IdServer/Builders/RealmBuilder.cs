﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using SimpleIdServer.IdServer.Domains;
using System;

namespace SimpleIdServer.IdServer.Builders
{
    public class RealmBuilder
    {
        private readonly Realm _realm;

        internal RealmBuilder(Realm realm)
        {
            _realm = realm;
        }

        public static RealmBuilder Create(string name, string description)
        {
            return new RealmBuilder(new Realm
            {
                Name = name,
                Description = description,
                CreateDateTime = DateTime.UtcNow,
                UpdateDateTime = DateTime.UtcNow
            });
        }

        public static RealmBuilder CreateMaster() => Create(Constants.DefaultRealm, Constants.DefaultRealm);

        public Realm Build() => _realm;
    }
}
