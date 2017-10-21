using System;
using System.Collections.Generic;
using System.Linq;
using Hangfire.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MtB
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var receiverId = Guid.NewGuid();
            var contact = new Contact() {ExternalId = receiverId};
            var email = new Email("hello");
            contact.ContactPreferences.Add(new EmailPreference());
            var messageTarnsmitter = new Mock<ITransmitEmail>();
            messageTarnsmitter.Setup(t => t.Transmit(contact, email)).Verifiable();

            var userId = new Guid();
            var applicationInstance =
                new EmailModule(
                    new UserContactsListFactory(new ContactListProvider(new[] {contact}.AsQueryable()),
                        new EmailContactFactory(messageTarnsmitter.Object), userId), null, userId);
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
            contact.ContactPreferences.Add(new EmailPreference());

            var contact2 = new Contact() {ExternalId = receiverId2};
            contact2.ContactPreferences.Add(new EmailPreference());

            var email = new Email("hello");
            var scheduleTask = new NewTaskSchedulerDouble();

            var messageTarnsmitter = new Mock<ITransmitEmail>();
            messageTarnsmitter.Setup(t => t.Transmit(contact , email)).Verifiable();
            messageTarnsmitter.Setup(t => t.Transmit(contact2 , email)).Verifiable();

            var applicationInstance =
                new EmailModule(
                    new UserContactsListFactory(new ContactListProvider(new[] {contact, contact2}.AsQueryable()),
                        new EmailContactFactory(messageTarnsmitter.Object), userId),  scheduleTask, userId);
            var app =  applicationInstance;

            app.SendEmailTo(new List<Guid>{receiverId, receiverId2}, email);
            messageTarnsmitter.Verify();
        }
    }

    public class NewTaskSchedulerDouble : ScheduleTask
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
