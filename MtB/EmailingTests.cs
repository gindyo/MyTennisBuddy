using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MtB.Communication;
using MtB.EmailComponents;
using MtB.SmsComponents;

namespace MtB
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSendingSms()
        {
            var receiverId = Guid.NewGuid();
            var contact = new Contact() {ExternalId = receiverId};
            var sms = new Sms("hello");
            contact.ComunicationCapabilities.Add(new ReceiveEmail());
            var messageTarnsmitter = new Mock<ITransmitSms>();
            messageTarnsmitter.Setup(t => t.Transmit(contact, sms)).Verifiable();

            var userId = new Guid();
            var smsContactFactory = new SmsContactFactory(messageTarnsmitter.Object);
            var emaContactFactory = new EmailContactFactory(null);
            var contactListProvider = new ContactListProvider(new[] {contact}.AsQueryable());
            var userContactsListFactory = new UserContactsListFactory(contactListProvider,emaContactFactory, smsContactFactory, userId);
            var applicationInstance = new CommunicationModule( userContactsListFactory, null, userId);
            var app =  applicationInstance;

          app.SendSmsTo(receiverId, sms);
          messageTarnsmitter.Verify();
        }
        [TestMethod]
        public void TestSendingSmsToMultipleReceivers()
        {
            var receiverId = Guid.NewGuid();
            var receiverId2 = Guid.NewGuid();

            var contact = new Contact() {ExternalId = receiverId};
            contact.ComunicationCapabilities.Add(new ReceiveSmsCapability());

            var contact2 = new Contact() {ExternalId = receiverId2};
            contact2.ComunicationCapabilities.Add(new ReceiveSmsCapability());
            var sms = new Sms("hello");
            contact.ComunicationCapabilities.Add(new ReceiveEmail());
            var messageTarnsmitter = new Mock<ITransmitSms>();
            messageTarnsmitter.Setup(t => t.Transmit(contact, sms)).Verifiable();

            var userId = new Guid();
            var smsContactFactory = new SmsContactFactory(messageTarnsmitter.Object);
            var emaContactFactory = new EmailContactFactory(null);
            var contactListProvider = new ContactListProvider(new[] {contact}.AsQueryable());
            var userContactsListFactory = new UserContactsListFactory(contactListProvider,emaContactFactory, smsContactFactory, userId);
            var applicationInstance = new CommunicationModule( userContactsListFactory, new TaskSchedulerDouble(), userId);
            var app =  applicationInstance;

          app.SendSmsTo(new []{receiverId, receiverId2}, sms);
          messageTarnsmitter.Verify();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var receiverId = Guid.NewGuid();
            var contact = new Contact() {ExternalId = receiverId};
            var email = new Email("hello");
            contact.ComunicationCapabilities.Add(new ReceiveEmail());
            var messageTarnsmitter = new Mock<ITransmitEmail>();
            messageTarnsmitter.Setup(t => t.Transmit(contact, email)).Verifiable();

            var userId = new Guid();
            var smsContactFactory = new SmsContactFactory(null);
            var emaContactFactory = new EmailContactFactory(messageTarnsmitter.Object);
            var contactListProvider = new ContactListProvider(new[] {contact}.AsQueryable());
            var userContactsListFactory = new UserContactsListFactory(contactListProvider,emaContactFactory, smsContactFactory, userId);
            var applicationInstance = new CommunicationModule( userContactsListFactory, null, userId);
            var app =  applicationInstance;

            app.SendEmailTo(receiverId, email);
            messageTarnsmitter.Verify();
        }

        [TestMethod]
        public void ScheduleEmailSending()
        {
            var userId = new Guid();
            var receiverId = Guid.NewGuid();
            var receiverId2 = Guid.NewGuid();

            var contact = new Contact() {ExternalId = receiverId};
            contact.ComunicationCapabilities.Add(new ReceiveEmail());

            var contact2 = new Contact() {ExternalId = receiverId2};
            contact2.ComunicationCapabilities.Add(new ReceiveEmail());

            var email = new Email("hello");
            var scheduleTask = new TaskSchedulerDouble();

            var messageTarnsmitter = new Mock<ITransmitEmail>();
            messageTarnsmitter.Setup(t => t.Transmit(contact , email)).Verifiable();
            messageTarnsmitter.Setup(t => t.Transmit(contact2 , email)).Verifiable();

            var emaContactFactory = new EmailContactFactory(messageTarnsmitter.Object);
            var contactListProvider = new ContactListProvider(new[] {contact, contact2}.AsQueryable());
            var userContactsListFactory = new UserContactsListFactory(contactListProvider,emaContactFactory,null, userId);
            var applicationInstance = new CommunicationModule( userContactsListFactory, scheduleTask, userId);
            var app =  applicationInstance;

            app.SendEmailTo(new List<Guid>{receiverId, receiverId2}, email);
            messageTarnsmitter.Verify();
        }
    }


    public class TaskSchedulerDouble : ScheduleTask
    {
        private Action _task;

        public override IScheduleTask Do(Action task)
        {
            _task = task;
            return this;
        }

        public override void StartCounting()
        {
            //instead of scheduling call task right away
            _task();
        }
    }
}
