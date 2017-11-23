using System;
using System.Linq;
using Core.Communication.Components.ForNotifyingAllChannels;
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
            var userContactsListFactory = new BuildUserContactList(contactListProvider, emaContactFactory, smsContactFactory, userId);
            var emailSender = new SendEmail(userContactsListFactory, null);
            var smsSender = new SendSms(userContactsListFactory, null);
            var notificationSender = new SendNotification(smsSender, emailSender);

            notificationSender.To(receiverId, messageText);
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
            var userContactsListFactory = new BuildUserContactList(contactListProvider, emaContactFactory, smsContactFactory, userId);
            var viaEmail = new SendEmail(userContactsListFactory, null);
            var viaSms = new SendSms(userContactsListFactory, null);
            var viaAllSupported = new SendNotification(viaSms, viaEmail);

            viaAllSupported.To(receiverId, messageText);
            smsTransmitter.Verify();
        }
    }
}