using System;
using System.Collections.Generic;
using System.Linq;
using MtB.Communication.Factories;
using MtB.Communication.Plugins;

namespace MtB.Communication.Components.ForSendingSms
{
    public class SendSms
    {
        private readonly BuildUserContactList _buildContactList;
        private readonly IScheduleTask _scheduleTask;
        private SmsContactList SmsContactList => _buildContactList.With(new ReceiveSmsCapability());

        public SendSms(BuildUserContactList buildContactList, IScheduleTask scheduleScheduleTask )
        {
            _buildContactList = buildContactList;
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