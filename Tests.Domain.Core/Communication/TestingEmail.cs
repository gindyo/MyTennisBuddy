using System;
using System.Collections.Generic;
using System.Linq;
using Core.Communication.Components.ForSendingEmail;
using Core.Communication.Entities;
using Core.Communication.Factories;
using Core.Communication.Plugins;
using Core.Tests.Communication.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Core.Tests.Communication
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
                new BuildUserContactList(contactListProvider, emaContactFactory, null, new Guid());
            var communicationModule = new SendEmail(userContactsListFactory, null);

            communicationModule.To(receiverId, email);
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
                new BuildUserContactList(contactListProvider, emaContactFactory, null, userId);
            var communicationModule = new SendEmail(userContactsListFactory, scheduleTask);

            communicationModule.To(new List<Guid> {receiverId, receiverId2}, email);
            messageTarnsmitter.Verify();
        }
    }
}