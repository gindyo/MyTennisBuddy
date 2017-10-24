using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MtB.Components.ForSendingEmail;
using MtB.Entities;
using MtB.Infrastructure;
using MtB.Infrastructure.ForCommunication;
using MtB.Infrastructure.ForManufacturing;
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
            var contact = new Contact {ExternalId = receiverId, Email = "c@g.com"};
            var email = new Email("hello",  contact.Email);
            contact.ComunicationCapabilities.Add(new ReceiveEmailCapability());
            var messageTarnsmitter = new Mock<ITransmitEmail>();
            messageTarnsmitter.Setup(t => t.Transmit(contact, email)).Verifiable();

            var emaContactFactory = new EmailContactFactory(messageTarnsmitter.Object);
            var contactListProvider = new ProvideContactsDouble(new[] {contact}.AsQueryable());
            var userContactsListFactory =
                new UserContacts(contactListProvider, emaContactFactory, null, new Guid());
            var communicationModule = new ViaEmail(userContactsListFactory, null);

            communicationModule.Send(receiverId, email);
            messageTarnsmitter.Verify();
        }

        [TestMethod]
        public void ScheduleEmailSendingToMultipleReceivers()
        {
            var userId = new Guid();
            var receiverId = Guid.NewGuid();
            var receiverId2 = Guid.NewGuid();

            var contact = new Contact {ExternalId = receiverId, Email = "c@g.com"};
            contact.ComunicationCapabilities.Add(new ReceiveEmailCapability());

            var contact2 = new Contact {ExternalId = receiverId2, Email = "c2@g.com"};
            contact2.ComunicationCapabilities.Add(new ReceiveEmailCapability());

            var email = new Email("hello",  contact.Email);
            var scheduleTask = new TaskSchedulerDouble();

            var email2 = new Email("hello",  contact2.Email);
            var messageTarnsmitter = new Mock<ITransmitEmail>();
            messageTarnsmitter.Setup(t => t.Transmit(contact, email)).Verifiable();
            messageTarnsmitter.Setup(t => t.Transmit(contact2, email2)).Verifiable();

            var emaContactFactory = new EmailContactFactory(messageTarnsmitter.Object);
            var contactListProvider = new ProvideContactsDouble(new[] {contact, contact2}.AsQueryable());
            var userContactsListFactory =
                new UserContacts(contactListProvider, emaContactFactory, null, userId);
            var communicationModule = new ViaEmail(userContactsListFactory, scheduleTask);

            communicationModule.Send(new List<Guid> {receiverId, receiverId2}, email);
            messageTarnsmitter.Verify();
        }
    }
}