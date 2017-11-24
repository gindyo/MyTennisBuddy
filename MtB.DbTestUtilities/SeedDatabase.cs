using System;
using System.Collections.Generic;
using Core.Communication.Components.ForSendingEmail;
using Repository.Entities;
using Repository.Providers;

namespace Tests.DbUtilities
{
    public class SeedDatabase
    {
        public MtbDbContext DbContext { get; }
        public SeedDatabase(MtbDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public  Friend CreateFriendFor(Guid userId )
        {
            var newGuid = Guid.NewGuid();
            var friend = new Friend()
            {
                UserId = userId,
                ExternalId = newGuid,
                FirstName = "Dimitar",
                LastName = "Ginev",
                CellPhoneNmuber = "23452345",
                Email = "dimitar@ginev.com",
                Position = 1,
                ComunicationCapabilities = new List<CommunicationCapability>()
                {
					new CommunicationCapability() {Type = typeof(ReceiveEmailCapability).ToString()}
                }
            };
            DbContext.Friends.Add(friend);
            DbContext.SaveChanges();
            return friend;
        }
    }
}
