using System;
using System.Collections.Generic;
using System.Linq;
using MtB.Communication.Entities;
using MtB.Communication.Factories;
using MtB.Communication.Plugins;

namespace MtB.Communication.Components.ForSendingEmail
{
    public class SendEmail
    {
        private readonly IScheduleTask _scheduleTask;
        private readonly BuildUserContactList _buildContactList;

        public SendEmail(BuildUserContactList buildContactList, IScheduleTask scheduleScheduleTask )
        {
            _buildContactList = buildContactList;
            _scheduleTask = scheduleScheduleTask;
        }

        private EmailContactList EmailContactList =>
            _buildContactList.With(new ReceiveEmailCapability());


        public void To(Guid receiver, Email email)
        {
            var emailContacts = EmailContactList.Get(new []{receiver});
            foreach (var emailContact in emailContacts)
            {
                emailContact.Receive(email);
            }

        }

        public void To(IEnumerable<Guid> list, Email email)
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


    }
}