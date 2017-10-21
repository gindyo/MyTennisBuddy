using System;
using System.Collections.Generic;
using System.Linq;

namespace MtB
{
    public class EmailModule
    {
        private readonly UserContactsListFactory _userContactsListFactory;
        private readonly IScheduleTask _scheduleTask;
        private readonly Guid _userId;

        public EmailModule(UserContactsListFactory userContactsListFactory, IScheduleTask scheduleScheduleTask, Guid userId)
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

        private EmailContactList EmailContactList  => _userContactsListFactory.GetEmailContactList();

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
    }
}