using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MtB.BuddyList;
using MtB.BuddyList.Entities;
using MtB.CommonValueObjects;
using MtB.Repository.Providers;
using MtB.Repository.Stores;

namespace MtB.EndToEndTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var buddyList = new AddBuddy(new BuddyStore(new MtbStore()), new BuddiesProvider(new MtbStore()));
            buddyList.New(new Buddy(Guid.NewGuid()){Name = new Name("Dimitar", "Ginev")});
        }
    }
}
