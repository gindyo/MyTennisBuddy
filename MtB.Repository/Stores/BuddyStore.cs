using System;
using Core.BuddyList.Entities;
using Core.BuddyList.Plugins;
using Repository.Entities;
using Repository.Providers;

namespace Repository.Stores
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
            Friend friend = new Friend(buddy) { UserId = UserId };
            _mtbStore.Entry(friend).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _mtbStore.SaveChanges();
        }


        public void Save(NewBuddy buddy)
        {
            _mtbStore.Add(new Friend(buddy) { UserId = UserId});
            _mtbStore.SaveChanges();

        }
    }
}
