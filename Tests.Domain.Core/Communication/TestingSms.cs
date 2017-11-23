using System;
using System.Linq;
using Core.Communication.Components.ForSendingEmail;
using Core.Communication.Components.ForSendingSms;
using Core.Communication.Entities;
using Core.Communication.Factories;
using Core.Communication.Plugins;
using Core.Tests.Communication.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Core.Tests.Communication
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
            var userContactsListFactory = new BuildUserContactList(contactListProvider, emaContactFactory, smsContactFactory, userId);
            var applicationInstance = new SendSms(userContactsListFactory, null);
            var app = applicationInstance;

            app.To(receiverId, sms);
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
                new BuildUserContactList(contactListProvider, null, smsContactFactory, userId);
            var app = new SendSms(userContactsListFactory, new TaskSchedulerDouble());

            app.To(new[] {receiverId, receiverId2}, sms);
            messageTarnsmitter.Verify();
        }
    }
} 