using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MtB.BuddyList.Entities;
using MtB.BuddyList.Factories;
using MtB.BuddyList.MoveOperations;

namespace MtB.Tests.BuddyList
{
    [TestClass]
    public class MoveBuddiesTests
    {
        [TestMethod]
        public void MoveOperationFactoryPromoteTest()
        {
            var factory = new MoveOperationsFactory(new Mock<IEnumerable<Buddy>>().Object);
            var buddy = new Buddy(new Guid()){Position = 5};
            var moveOperation = factory.GetMoveOperation(buddy, 1);
            Assert.IsInstanceOfType(moveOperation, typeof(Promote));
        }
        [TestMethod]
        public void MoveOperationFactoryDemoteTest()
        {
            var buddy1 = new Buddy(Guid.NewGuid()) {Position = 1};
            var buddy2 = new Buddy(Guid.NewGuid()) {Position = 2};
            var buddies = new List<Buddy>{ buddy1,buddy2 }.AsQueryable();
            var factory = new MoveOperationsFactory(buddies);
            var moveOperation = factory.GetMoveOperation(buddy1, 2);
            Assert.IsInstanceOfType(moveOperation, typeof(Demote));
        }

        [TestMethod]
        public void PromoteABuddy()
        {
            var buddy1 = new Buddy(Guid.NewGuid()) {Position = 1};
            var buddy2 = new Buddy(Guid.NewGuid()) {Position = 2};
            var buddy3 = new Buddy(Guid.NewGuid()) {Position = 3};
            var buddy4 = new Buddy(Guid.NewGuid()) {Position = 4};
            var buddy5 = new Buddy(Guid.NewGuid()) {Position = 5};
            var buddies = new List<Buddy>()
            {
                buddy1,
                buddy2,
                buddy3,
                buddy4,
                buddy5,
            }.AsQueryable();
            var promote = new  Promote(buddies, buddy3, 1 );
            promote.Execute();

            var expectToBeAffected = new List<Buddy>(){buddy1, buddy2, buddy3};
            CollectionAssert.AreEqual(expectToBeAffected, promote.Affected );

            Assert.AreEqual(1, buddy3.Position);
            Assert.AreEqual(2, buddy1.Position);
            Assert.AreEqual(3, buddy2.Position);

            //4 and 5 are not affected
            Assert.IsFalse(promote.Affected.Any( b => Equals(b, buddy4)));
            Assert.IsFalse(promote.Affected.Any( b => Equals(b, buddy5)));
            Assert.AreEqual(4, buddy4.Position);
            Assert.AreEqual(5, buddy5.Position);
        }
        
        [TestMethod]
        public void PromoteABuddyWithInvalidArguments()
        {
            var buddy1 = new Buddy(Guid.NewGuid()) {Position = 1};
            var buddies = new List<Buddy>() { buddy1, }.AsQueryable();
            Assert.ThrowsException<ArgumentException>(() => new Promote(buddies, buddy1, 0));
            Assert.ThrowsException<ArgumentException>(() => new Promote(buddies, buddy1, 2));
        }

        [TestMethod]
        public void DemoteABuddyWithInvalidArguments()
        {
            var buddy1 = new Buddy(Guid.NewGuid()) {Position = 1};
            var buddy2 = new Buddy(Guid.NewGuid()) {Position = 2};
            var buddies = new List<Buddy>() { buddy1, buddy2 }.AsQueryable();
            Assert.ThrowsException<ArgumentException>(() => new Demote(buddies, buddy1, 3));
            Assert.ThrowsException<ArgumentException>(() => new Demote(buddies, buddy2, 1));
        }
        [TestMethod]
        public void DemoteABuddy()
        {
            var buddy1 = new Buddy(Guid.NewGuid()) {Position = 1};
            var buddy2 = new Buddy(Guid.NewGuid()) {Position = 2};
            var buddy3 = new Buddy(Guid.NewGuid()) {Position = 3};
            var buddy4 = new Buddy(Guid.NewGuid()) {Position = 4};
            var buddy5 = new Buddy(Guid.NewGuid()) {Position = 5};
            var buddies = new List<Buddy>()
            {
                buddy1,
                buddy2,
                buddy3,
                buddy4,
                buddy5,
            }.AsQueryable();
            var demote = new  Demote(buddies, buddy2, 5 );
            demote.Execute();

            var expectToBeAffected = new List<Buddy>(){ buddy2, buddy3, buddy4, buddy5};
            CollectionAssert.AreEqual(expectToBeAffected, demote.Affected );

            Assert.AreEqual(2, buddy3.Position);
            Assert.AreEqual(3, buddy4.Position);
            Assert.AreEqual(4, buddy5.Position);
            Assert.AreEqual(5, buddy2.Position);

            //1 is not affected
            Assert.IsFalse(demote.Affected.Any( b => Equals(b, buddy1)));
            Assert.AreEqual(1, buddy1.Position);
        }

    }
}