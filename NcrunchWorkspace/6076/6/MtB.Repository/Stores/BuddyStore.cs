using System;
using System.Collections.Generic;
using MtB.BuddyList;
using MtB.BuddyList.Entities;
using MtB.BuddyList.Plugins;
using MtB.Repository.Entities;
using MtB.Repository.Providers;

namespace MtB.Repository.Stores
{
    public class BuddyStore: IStoreBuddies
    {
        private readonly MtbStore _mtbStore;

        public BuddyStore(MtbStore mtbStore, Guid userId)
        {
            _mtbStore = mtbStore;
            UserId = userId;
        }

        public Guid UserId { get; }

        public void Update(Buddy buddy)
        {
            _mtbStore.Update(new Friend(buddy) { UserId = UserId });
            _mtbStore.SaveChanges();
        }

        public void Save(IEnumerable<Buddy> affected)
        {
        }

        public void Save(NewBuddy buddy)
        {
            _mtbStore.Add(new Friend(buddy) { UserId = UserId});
            _mtbStore.SaveChanges();

        }
    }
}
