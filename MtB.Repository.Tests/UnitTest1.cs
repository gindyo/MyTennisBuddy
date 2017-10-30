using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MtB.Communication.Components.ForSendingEmail;
using MtB.Repository.Entities;

namespace MtB.Repository.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FriendsProvider friendsProvider = new FriendsProvider(); 
            var newGuid = SeedDb( friendsProvider);
            var buddiesProvider = new BuddiesProvider(friendsProvider);
            var buddy = buddiesProvider.First(b => b.ExternalId == newGuid);
            Assert.AreEqual("Dimitar Ginev", buddy.Name.ToString());
                
        }

        [TestMethod]
        public void TestMethod2()
        {
            FriendsProvider friendsProvider = new FriendsProvider(); 
            var newGuid = SeedDb( friendsProvider);
            var contactsProvider = new ContactsProvider(friendsProvider);
            var contact = contactsProvider.First(b => b.ExternalId == newGuid);
            Assert.IsTrue(contact.ComunicationCapabilities.Any(c=> c is ReceiveEmailCapability));
                
        }


        private static Guid SeedDb( FriendsProvider friendsProvider)
        {
            var newGuid = Guid.NewGuid();
            var friend = new Friend()
            {
                ExternalId = newGuid,
                FirstName = "Dimitar",
                LastName = "Ginev",
                CellPhoneNmuber = "23452345",
                ComunicationCapabilities = new List<CommunicationCapability>()
                {
                    new CommunicationCapability() {Type = typeof(ReceiveEmailCapability).ToString()}
                }
            };
            friendsProvider.Friends.Add(friend);
            friendsProvider.SaveChanges();
            return newGuid;
        }
    }
}
