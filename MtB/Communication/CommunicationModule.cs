using System;
using System.Collections.Generic;
using System.Linq;
using MtB.EmailComponents;
using MtB.SmsComponents;

namespace MtB.Communication
{
    public class CommunicationModule
    {
        private readonly UserContactsListFactory _userContactsListFactory;
        private readonly IScheduleTask _scheduleTask;
        private readonly Guid _userId;

        public CommunicationModule(UserContactsListFactory userContactsListFactory, IScheduleTask scheduleScheduleTask, Guid userId)
        {
            _userContactsListFactory = userContactsListFactory;
            _scheduleTask = scheduleScheduleTask;
            _userId = userId;
        }

        public void SendEmailTo(Guid receiver, Email email)
        {
            var emailContact = EmailContactList.Get(receiver);
            emailContact.ReceiveEmail(email);
        }

        private EmailContactList EmailContactList  => _userContactsListFactory.GetContactListFor(new EmailPreference());
        private SmsContactList SmsContactList  => _userContactsListFactory.GetContactListFor(new ReceiveSmsCapability());

        internal void SendEmailTo(List<Guid> list, Email email)
        {
            var emailContacts = EmailContactList
                .Get(list)
                .OrderBy(c => c.SequenceNum)
                .ToList();
            foreach (var contact in emailContacts)
            {
                _scheduleTask.Do(() => contact.ReceiveEmail(email));
                _scheduleTask.In(TimeSpan.FromMinutes(5));
                _scheduleTask.StartCounting();
            }
        }

        public void SendSmsTo(Guid receiverId, Sms sms)
        {
                SmsContactList.Get(receiverId).Receive(sms);
        }

        internal void SendSmsTo(IEnumerable<Guid> list, Sms sms)
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
    }
}