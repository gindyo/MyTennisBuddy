using System;
using System.Collections.Generic;
using System.Linq;
using MtB.Components.ForSendingSms;
using MtB.Entities;
using MtB.Infrastructure.ForManufacturing;
using MtB.Plugins;

namespace MtB.Infrastructure.ForCommunication
{
    public class ViaSms
    {
        private UserContacts _userContactsListFactory;
        private IScheduleTask _scheduleTask;
        private SmsContactList SmsContactList => _userContactsListFactory.GetContactListFor(new ReceiveSmsCapability());

        public ViaSms(UserContacts userContactsListFactory, IScheduleTask scheduleScheduleTask )
        {
            _userContactsListFactory = userContactsListFactory;
            _scheduleTask = scheduleScheduleTask;
        }
        public void Send(Guid receiverId, Sms sms)
        {
            SmsContactList.Get(receiverId).Receive(sms);
        }

        public void Send(IEnumerable<Guid> list, Sms sms)
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