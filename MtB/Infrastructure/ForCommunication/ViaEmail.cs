using System;
using System.Collections.Generic;
using System.Linq;
using MtB.Components.ForSendingEmail;
using MtB.Entities;
using MtB.Infrastructure.ForManufacturing;
using MtB.Plugins;

namespace MtB.Infrastructure.ForCommunication
{
    public class ViaEmail
    {
        private readonly IScheduleTask _scheduleTask;
        private readonly UserContacts _userContactsListFactory;

        public ViaEmail(UserContacts userContactsListFactory, IScheduleTask scheduleScheduleTask )
        {
            _userContactsListFactory = userContactsListFactory;
            _scheduleTask = scheduleScheduleTask;
        }

        private EmailContactList EmailContactList =>
            _userContactsListFactory.GetContactListFor(new ReceiveEmailCapability());


        public void Send(Guid receiver, Email email)
        {
            var emailContact = EmailContactList.Get(receiver);
            emailContact.Receive(email);
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