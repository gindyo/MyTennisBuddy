using System;
using Core.BuddyList.Entities;
using Core.BuddyList.Plugins;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            var buddyRecord = _mtbDbContext.BuddyRecords.Find(b => b.ExternalId == buddy.ExternalId);
            buddyRecord.Update(buddy);
            _mtbDbContext.SaveChanges();
        }

        private void MarkUpdatedFields(EntityEntry<BuddyRecord> entry, Buddy buddy)
        {
            entry.Property(b => b.Position).IsModified = entry.Entity.Position != buddy.Position;
            entry.Property(b => b.Email).IsModified = entry.Entity.Email != buddy.ContactInfo.Email;
            entry.Property(b => b.CellPhoneNmuber).IsModified = entry.Entity.CellPhoneNmuber != buddy.ContactInfo.CellPhoneNumber;
            entry.Property(b => b.FirstName).IsModified = entry.Entity.FirstName != buddy.Name.First;
            entry.Property(b => b.LastName).IsModified = entry.Entity.LastName != buddy.Name.Last;
        }


        public void Save(NewBuddy buddy)
        {
            _mtbDbContext.BuddyRecords.Add(new BuddyRecord(buddy) { UserId = UserId});
            _mtbDbContext.SaveChanges();

        }
    }
}
