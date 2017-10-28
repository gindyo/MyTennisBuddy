using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MtB.Communication.Components;
using MtB.Communication.Components.ForNotifyingAllChannels;
using MtB.Communication.Components.ForSendingEmail;
using MtB.Communication.Components.ForSendingSms;
using MtB.Communication.Entities;
using MtB.Communication.Factories;
using MtB.Communication.Plugins;
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
            var userContactsListFactory = new BuildUserContactList(contactListProvider, emaContactFactory, smsContactFactory, userId);
            var emailSender = new ViaEmail(userContactsListFactory, null);
            var smsSender = new ViaSms(userContactsListFactory, null);
            var notificationSender = new ViaAllSupportedDevices(smsSender, emailSender);

            notificationSender.Send(receiverId, messageText);
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
            var viaEmail = new ViaEmail(userContactsListFactory, null);
            var viaSms = new ViaSms(userContactsListFactory, null);
            var viaAllSupported = new ViaAllSupportedDevices(viaSms, viaEmail);

            viaAllSupported.Send(receiverId, messageText);
            smsTransmitter.Verify();
        }
    }
}