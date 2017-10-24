using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MtB.Components.ForSendingEmail;
using MtB.Components.ForSendingSms;
using MtB.Entities;
using MtB.Infrastructure;
using MtB.Infrastructure.ForCommunication;
using MtB.Infrastructure.ForManufacturing;
using MtB.Plugins;
using MtB.Tests.TestDoubles;

namespace MtB.Tests
{

    [TestClass]
    public class TestingSms
    {
        [TestMethod]
        public void TestSendingSms()
        {
            var receiverId = Guid.NewGuid();
            var contact = new Contact {ExternalId = receiverId};
            var sms = new Sms("hello");
            contact.ComunicationCapabilities.Add(new ReceiveEmailCapability());
            var messageTarnsmitter = new Mock<ITransmitSms>();
            messageTarnsmitter.Setup(t => t.Transmit(contact, sms)).Verifiable();

            var userId = new Guid();
            var smsContactFactory = new SmsContactFactory(messageTarnsmitter.Object);
            var emaContactFactory = new EmailContactFactory(null);
            var contactListProvider = new ProvideContactsDouble(new[] {contact}.AsQueryable());
            var userContactsListFactory = new UserContacts(contactListProvider, emaContactFactory, smsContactFactory, userId);
            var applicationInstance = new ViaSms(userContactsListFactory, null);
            var app = applicationInstance;

            app.Send(receiverId, sms);
            messageTarnsmitter.Verify();
        }

        [TestMethod]
        public void TestSendingSmsToMultipleReceivers()
        {
            var receiverId = Guid.NewGuid();
            var receiverId2 = Guid.NewGuid();

            var contact = new Contact {ExternalId = receiverId};
            contact.ComunicationCapabilities.Add(new ReceiveSmsCapability());

            var contact2 = new Contact {ExternalId = receiverId2};
            contact2.ComunicationCapabilities.Add(new ReceiveSmsCapability());
            var sms = new Sms("hello");
            contact.ComunicationCapabilities.Add(new ReceiveEmailCapability());
            var messageTarnsmitter = new Mock<ITransmitSms>();
            messageTarnsmitter.Setup(t => t.Transmit(contact, sms)).Verifiable();

            var userId = new Guid();
            var smsContactFactory = new SmsContactFactory(messageTarnsmitter.Object);
            var contactListProvider = new ProvideContactsDouble(new[] {contact}.AsQueryable());
            var userContactsListFactory =
                new UserContacts(contactListProvider, null, smsContactFactory, userId);
            var app = new ViaSms(userContactsListFactory, new TaskSchedulerDouble());

            app.Send(new[] {receiverId, receiverId2}, sms);
            messageTarnsmitter.Verify();
        }
    }
} 