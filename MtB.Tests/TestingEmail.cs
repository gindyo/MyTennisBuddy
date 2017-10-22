using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MtB.EmailComponents;
using MtB.Entities;
using MtB.Infrastructure;
using MtB.Plugins;
using MtB.Tests.TestDoubles;

namespace MtB.Tests
{
    [TestClass]
    public class TestingEmail
    {
        [TestMethod]
        public void SendEmailToSingleReceiver()
        {
            var receiverId = Guid.NewGuid();
            var contact = new Contact {ExternalId = receiverId};
            var email = new Email("hello");
            contact.ComunicationCapabilities.Add(new ReceiveEmailCapability());
            var messageTarnsmitter = new Mock<ITransmitEmail>();
            messageTarnsmitter.Setup(t => t.Transmit(contact, email)).Verifiable();

            var emaContactFactory = new EmailContactFactory(messageTarnsmitter.Object);
            var contactListProvider = new ProvideContactsDouble(new[] {contact}.AsQueryable());
            var userContactsListFactory =
                new UserContactsListFactory(contactListProvider, emaContactFactory, null, new Guid());
            var communicationModule = new CommunicationModule(userContactsListFactory, null, new Guid());

            communicationModule.SendEmailTo(receiverId, email);
            messageTarnsmitter.Verify();
        }

        [TestMethod]
        public void ScheduleEmailSendingToMultipleReceivers()
        {
            var userId = new Guid();
            var receiverId = Guid.NewGuid();
            var receiverId2 = Guid.NewGuid();

            var contact = new Contact {ExternalId = receiverId};
            contact.ComunicationCapabilities.Add(new ReceiveEmailCapability());

            var contact2 = new Contact {ExternalId = receiverId2};
            contact2.ComunicationCapabilities.Add(new ReceiveEmailCapability());

            var email = new Email("hello");
            var scheduleTask = new TaskSchedulerDouble();

            var messageTarnsmitter = new Mock<ITransmitEmail>();
            messageTarnsmitter.Setup(t => t.Transmit(contact, email)).Verifiable();
            messageTarnsmitter.Setup(t => t.Transmit(contact2, email)).Verifiable();

            var emaContactFactory = new EmailContactFactory(messageTarnsmitter.Object);
            var contactListProvider = new ProvideContactsDouble(new[] {contact, contact2}.AsQueryable());
            var userContactsListFactory =
                new UserContactsListFactory(contactListProvider, emaContactFactory, null, userId);
            var communicationModule = new CommunicationModule(userContactsListFactory, scheduleTask, userId);

            communicationModule.SendEmailTo(new List<Guid> {receiverId, receiverId2}, email);
            messageTarnsmitter.Verify();
        }
    }
}