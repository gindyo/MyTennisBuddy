using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MtB.EmailComponents;
using MtB.Entities;
using MtB.Infrastructure;
using MtB.Plugins;
using MtB.SmsComponents;
using MtB.Tests.TestDoubles;

namespace MtB.Tests
{
    [TestClass]
    public class TestingAllCapableDevices
    {
        [TestMethod]
        public void TestSendingSmsAndEmail()
        {
            var receiverId = Guid.NewGuid();

            var contact = new Contact {ExternalId = receiverId};
            contact.ComunicationCapabilities.Add(new ReceiveEmailCapability());
            contact.ComunicationCapabilities.Add(new ReceiveSmsCapability());

            var smsTransmitter = new Mock<ITransmitSms>();
            var emailTransmitter = new Mock<ITransmitEmail>();
            var messageText = "Hello";
            
            Sms sms = new Sms(messageText);
            Email email = new Email(messageText);

            smsTransmitter.Setup(t => t.Transmit(contact, sms)).Verifiable();
            emailTransmitter.Setup(t => t.Transmit(contact, email)).Verifiable();

            var userId = new Guid();
            var smsContactFactory = new SmsContactFactory(smsTransmitter.Object);
            var emaContactFactory = new EmailContactFactory(emailTransmitter.Object);

            var contactListProvider = new ProvideContactsDouble(new[] {contact}.AsQueryable());
            var userContactsListFactory =
                new UserContactsListFactory(contactListProvider, emaContactFactory, smsContactFactory, userId);
            var applicationInstance = new CommunicationModule(userContactsListFactory, null, userId);
            var app = applicationInstance;

            app.SendToAllSupportedDevices(receiverId, messageText);
            smsTransmitter.Verify();
        }
        [TestMethod]
        public void TestSendingSms()
        {
            var receiverId = Guid.NewGuid();

            var contact = new Contact {ExternalId = receiverId};
            contact.ComunicationCapabilities.Add(new ReceiveSmsCapability());

            var smsTransmitter = new Mock<ITransmitSms>();
            var emailTransmitter = new Mock<ITransmitEmail>();
            var messageText = "Hello";
            
            Sms sms = new Sms(messageText);
            Email email = new Email(messageText);

            smsTransmitter.Setup(t => t.Transmit(contact, sms)).Verifiable();
            emailTransmitter.Setup(t => t.Transmit(contact, email)).Verifiable();

            var userId = new Guid();
            var smsContactFactory = new SmsContactFactory(smsTransmitter.Object);
            var emaContactFactory = new EmailContactFactory(emailTransmitter.Object);

            var contactListProvider = new ProvideContactsDouble(new[] {contact}.AsQueryable());
            var userContactsListFactory =
                new UserContactsListFactory(contactListProvider, emaContactFactory, smsContactFactory, userId);
            var applicationInstance = new CommunicationModule(userContactsListFactory, null, userId);
            var app = applicationInstance;

            app.SendToAllSupportedDevices(receiverId, messageText);
            smsTransmitter.Verify();
        }
    }
}