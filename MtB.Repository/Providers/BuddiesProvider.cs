using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MtB.BuddyList;
using MtB.Repository.Entities;

namespace MtB.Repository.Providers
{
    public class BuddiesProvider : IProvideBuddies
    {
        private readonly MtbStore _mtbStore;

        public BuddiesProvider(MtbStore friendsProvider)
        {
            _mtbStore = friendsProvider;
        }

        public IEnumerator<Buddy> GetEnumerator()
        {
            return _mtbStore.Friends.Select(ToBuddy).GetEnumerator();
        }

        private Buddy ToBuddy(Friend friend)
        {
            return friend.ToBuddy();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType => typeof(Buddy);
        public Expression Expression => _mtbStore.Friends.Select(f => f.ToBuddy()).AsQueryable().Expression;
        public IQueryProvider Provider => _mtbStore.Friends.Select(f => f.ToBuddy()).AsQueryable().Provider;
        public void Save(Buddy buddy)
        {

        }
    }
}