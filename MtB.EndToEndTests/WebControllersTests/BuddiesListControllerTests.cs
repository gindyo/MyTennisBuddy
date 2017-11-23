using System;
using System.Collections.Generic;
using System.Linq;
using Core.BuddyList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Providers;
using Repository.Stores;
using Tests.DbUtilities;
using Web.Controllers;
using Web.WebModels;

namespace Tests.EndToEnd.WebControllersTests
{
    [TestClass]
    public class BuddiesListControllerTests
    {
        [TestMethod]
        public void GetAListOfAllBuddies()
        {
            Guid userId = Guid.NewGuid();
            MtbStore store = new MtbStore();
            var friend = new SeedDatabase(store).CreateFriendFor(userId);
            BuddiesProvider provider = new BuddiesProvider(new MtbStore(), userId);
            BuddyStore bstore = new BuddyStore(new MtbStore(), userId);
            ListBuddies listBuddies = new ListBuddies(provider);
            IAddBuddy addBuddy = new AddBuddy(bstore, provider);
            var controller = new BuddiesListController(listBuddies, addBuddy);
            var buddiesJson = controller.Buddies();
            Assert.IsNotNull((buddiesJson.Value as IEnumerable<WebBuddy>).ToList().Single(b=> friend.ExternalId == b.externalId));
        }
        [TestMethod]
        public void SaveANewBuddy()
        {
            Guid userId = Guid.NewGuid();
            MtbStore store = new MtbStore();
            BuddiesProvider provider = new BuddiesProvider(new MtbStore(), userId);
            BuddyStore bstore = new BuddyStore(store, userId);
            ListBuddies listBuddies = new ListBuddies(provider);
            IAddBuddy addBuddy = new AddBuddy(bstore, provider);
            var controller = new BuddiesListController(listBuddies, addBuddy);
            WebBuddy buddy = new WebBuddy() { cellPhoneNumber = "12345", email = "email@bla.com", firstName = "dimitar"};
            var buddiesJson = controller.New(buddy);
            var buddies = controller.Buddies().Value as IEnumerable<WebBuddy>;
            var saved = buddies.First(b => b.externalId == buddy.externalId);

            Assert.AreEqual(buddy.firstName, saved.firstName);
            Assert.AreEqual(buddy.email, saved.email);
            Assert.AreEqual(buddy.cellPhoneNumber, saved.cellPhoneNumber);
            Assert.AreEqual(1, saved.position);
        }
    }
}
