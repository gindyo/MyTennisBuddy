using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MtB.BuddyList;
using MtB.BuddyList.Entities;
using MtB.CommonValueObjects;
using MtB.Repository.Providers;
using MtB.Repository.Stores;

namespace MtB.Tests.EndToEnd
{
    [TestClass]
    public class AddNewBuddyTests
    {
        [TestMethod]
        public void TestAddingNewBuddy()
        {
            var userId = new Guid("9824A957-7056-4659-BF81-3B70F6329E3A");
            var addBuddy = new AddBuddy(new BuddyStore(new MtbStore(), userId), new BuddiesProvider(new MtbStore(), userId));
            Buddy buddy = new Buddy(Guid.NewGuid()) { Name = new Name("Dimitar", "Ginev"), ContactInfo = new ContactInfo("", "") };
            addBuddy.New(new NewBuddy(buddy));
        }
    }
}
