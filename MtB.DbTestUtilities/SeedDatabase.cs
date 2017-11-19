using MtB.Communication.Components.ForSendingEmail;
using MtB.Repository.Entities;
using MtB.Repository.Providers;
using System;
using System.Collections.Generic;

namespace MtB.DbTestUtilities
{
    public class SeedDatabase
    {
        public MtbStore Store { get; }
        public SeedDatabase(MtbStore store)
        {
            Store = store;
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
            Store.Friends.Add(friend);
            Store.SaveChanges();
            return friend;
        }
    }
}
