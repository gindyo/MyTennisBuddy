﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core.BuddyList.Entities;
using Core.BuddyList.Plugins;

namespace Repository.Providers
{
    public class BuddiesProvider : IProvideBuddies
    {
        private readonly MtbDbContext _mtbDbContext;
        public Guid UserId { get; }

        public  BuddiesProvider(MtbDbContext friendsProvider, Guid userId)
        {
            _mtbDbContext = friendsProvider;
            UserId = userId;
        }

        public IEnumerator<Buddy> GetEnumerator()
        {
            return _mtbDbContext.BuddyRecords.AsQueryable().Where(f => f.UserId == UserId).Select(f => f.ToBuddy()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}