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
            Friend friend = new Friend(buddy) { UserId = UserId };
            _mtbDbContext.Entry(friend).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _mtbDbContext.SaveChanges();
        }


        public void Save(NewBuddy buddy)
        {
            _mtbDbContext.Add(new Friend(buddy) { UserId = UserId});
            _mtbDbContext.SaveChanges();

        }
    }
}
