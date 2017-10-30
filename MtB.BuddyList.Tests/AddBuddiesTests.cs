using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
            var provider = new List<Buddy>()
            {
                new Buddy(new Guid()) {NotificationSequenceNumber = 1},
                new Buddy(new Guid()) {NotificationSequenceNumber = 2}
            }.AsQueryable();

            var addBuddy = new AddBuddy(store.Object, provider);
            addBuddy.New(buddy);

            store.Verify(s => s.Save(It.Is<Buddy>(b => b.NotificationSequenceNumber == 3)) );
        }
    }
}
