using System;
using System.Collections.Generic;
using System.Linq;
using MtB.EmailComponents;
using MtB.Entities;
using MtB.Plugins;
using MtB.SmsComponents;

namespace MtB.Infrastructure
{
    public class CommunicationModule
    {
        private readonly IScheduleTask _scheduleTask;
        private readonly UserContactsListFactory _userContactsListFactory;
        private readonly Guid _userId;

        public CommunicationModule(UserContactsListFactory userContactsListFactory, IScheduleTask scheduleScheduleTask,
            Guid userId)
        {
            _userContactsListFactory = userContactsListFactory;
            _scheduleTask = scheduleScheduleTask;
            _userId = userId;
        }

        private EmailContactList EmailContactList =>
            _userContactsListFactory.GetContactListFor(new ReceiveEmailCapability());

        private SmsContactList SmsContactList => _userContactsListFactory.GetContactListFor(new ReceiveSmsCapability());

        public void SendEmailTo(Guid receiver, Email email)
        {
            var emailContact = EmailContactList.Get(receiver);
            emailContact.Receive(email);
        }

        public void SendEmailTo(List<Guid> list, Email email)
        {
            var emailContacts = EmailContactList
                .Get(list)
                .OrderBy(c => c.SequenceNum)
                .ToList();
            foreach (var contact in emailContacts)
            {
                _scheduleTask.Do(() => contact.Receive(email));
                _scheduleTask.In(TimeSpan.FromMinutes(5));
                _scheduleTask.StartCounting();
            }
        }

        public void SendSmsTo(Guid receiverId, Sms sms)
        {
            SmsContactList.Get(receiverId).Receive(sms);
        }

        public void SendSmsTo(IEnumerable<Guid> list, Sms sms)
        {
            var emailContacts = SmsContactList
                .Get(list)
                .OrderBy(c => c.SequenceNum)
                .ToList();
            foreach (var contact in emailContacts)
            {
                _scheduleTask.Do(() => contact.Receive(sms));
                _scheduleTask.In(TimeSpan.FromMinutes(5));
                _scheduleTask.StartCounting();
            }
        }

        public void SendToAllSupportedDevices(Guid receiverId, string text)
        {
            foreach (var contact in SmsContactList.Get(new []{receiverId}))
            {
                contact.Receive(new Sms(text));
            }
            foreach (var contact in EmailContactList.Get(new []{receiverId}))
            {
                contact.Receive(new Email(text));
            }
            
        }
    }
}