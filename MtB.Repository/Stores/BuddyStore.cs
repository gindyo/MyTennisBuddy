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

        public BuddyStore(MtbStore mtbStore)
        {
            _mtbStore = mtbStore;
        }

        public void Save(Buddy buddy)
        {
            _mtbStore.Add(new Friend(buddy));
            _mtbStore.SaveChanges();
        }

        public void Save(IEnumerable<Buddy> affected)
        {
        }
    }
}
