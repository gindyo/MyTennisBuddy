using System;
using Core.BuddyList.Entities;
using Core.BuddyList.Plugins;
using Repository.Entities;
using Repository.Providers;

namespace Repository.Stores
{
    public class BuddyStore: IStoreBuddies
    {
        private readonly MtbDbContext _mtbDbContext;

        public BuddyStore(MtbDbContext mtbDbContext, Guid userId)
        {
            _mtbDbContext = mtbDbContext;
            UserId = userId;
        }

        public Guid UserId { get; }

        public void Update(Buddy buddy)
        {
            BuddyRecord buddyRecord = new BuddyRecord(buddy) { UserId = UserId };
            _mtbDbContext.Entry(buddyRecord).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _mtbDbContext.SaveChanges();
        }


        public void Save(NewBuddy buddy)
        {
            _mtbDbContext.Add(new BuddyRecord(buddy) { UserId = UserId});
            _mtbDbContext.SaveChanges();

        }
    }
}
