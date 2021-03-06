using System;
using System.Linq;
using Core.Communication.Components.ForSendingEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Providers;
using Tests.DbUtilities;

namespace Repository.Tests
{
    [TestClass]
    public class ProviderTests
    {

        private static Guid userId = new Guid("9824A957-7056-4659-BF81-3B70F6321E3A");
        [TestMethod]
        public void TestMethod1()
        {
            var friendsProvider = new MtbDbContext(); 
            var newGuid = new SeedDatabase( friendsProvider).CreateFriendFor(userId).ExternalId;
            var buddiesProvider = new BuddiesProvider(friendsProvider, userId);
            var buddy = buddiesProvider.First(b => b.ExternalId == newGuid);
            Assert.AreEqual("Dimitar Ginev", buddy.Name.ToString());
                
        }

        [TestMethod]
        public void ContactsProviderRetrievesContact ()
        {
            var friendsProvider = new MtbDbContext(); 
            var newGuid = new SeedDatabase( friendsProvider).CreateFriendFor(userId).ExternalId;
            var contactsProvider = new ContactsProvider(friendsProvider);
            var contact = contactsProvider.First(b => b.ExternalId == newGuid);
            Assert.IsTrue(contact.ComunicationCapabilities.Any(c=> c is ReceiveEmailCapability));
        }


    }
}
    