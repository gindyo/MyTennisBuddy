using System;
using System.Collections.Generic;
using System.Linq;
using Core.BuddyList;
using Core.BuddyList.Entities;
using Core.BuddyList.Plugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Core.Tests.BuddyList
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

            store.Verify(s => s.Save(It.Is<NewBuddy>(b => b.Position == 3)) );
        }
       
        private static IEnumerable<Buddy> Buddies
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
