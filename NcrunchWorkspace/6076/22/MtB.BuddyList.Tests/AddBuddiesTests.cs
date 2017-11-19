using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MtB.BuddyList.Entities;
using MtB.BuddyList.Plugins;

namespace MtB.BuddyList.Tests
{
    [TestClass]
    public class AddBuddiesTests
    {
        [TestMethod]
        public void NewBuddyGetsTheLastContactSequenceNumberTest()
        {
            Guid buddyGuid = Guid.NewGuid(); 
            Buddy buddy = new Buddy(buddyGuid);
            var store = new Mock<IStoreBuddies>();

            var addBuddy = new AddBuddy(store.Object, Buddies);
            addBuddy.New(new NewBuddy(buddy));

            store.Verify(s => s.Update(It.Is<NewBuddy>(b => b.Position == 3)) );
        }

        private static IQueryable<Buddy> Buddies
        {
            get
            {
                return new List<Buddy>()
                {
                    new Buddy(new Guid()) {Position = 1},
                    new Buddy(new Guid()) {Position = 2}
                }.AsQueryable();
            }
        }
    }
}
