using System;
using System.Collections.Generic;
using System.Linq;
using MtB.Communication.Entities;
using MtB.Communication.Factories;
using MtB.Communication.Plugins;

namespace MtB.Communication.Components.ForSendingEmail
{
    public class ViaEmail
    {
        private readonly IScheduleTask _scheduleTask;
        private readonly BuildUserContactList _userContactsListFactory;

        public ViaEmail(BuildUserContactList userContactsListFactory, IScheduleTask scheduleScheduleTask )
        {
            _userContactsListFactory = userContactsListFactory;
            _scheduleTask = scheduleScheduleTask;
        }

        private EmailContactList EmailContactList =>
            _userContactsListFactory.GetContactListFor(new ReceiveEmailCapability());


        public void Send(Guid receiver, Email email)
        {
            var emailContacts = EmailContactList.Get(new []{receiver});
            foreach (var emailContact in emailContacts)
            {
                emailContact.Receive(email);
            }

        }

        public void Send(IEnumerable<Guid> list, Email email)
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