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
        private readonly MtbStore _mtbStore;
        public Guid UserId { get; }

        public BuddiesProvider(MtbStore friendsProvider, Guid userId)
        {
            _mtbStore = friendsProvider;
            UserId = userId;
        }

        public IEnumerator<Buddy> GetEnumerator()
        {
            return _mtbStore.Friends.AsQueryable().Where(f => f.UserId == UserId).Select(f => f.ToBuddy()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}