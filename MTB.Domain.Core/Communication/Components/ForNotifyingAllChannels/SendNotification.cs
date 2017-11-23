using System;
using System.Collections.Generic;
using Core.Communication.Components.ForSendingEmail;
using Core.Communication.Components.ForSendingSms;

namespace Core.Communication.Components.ForNotifyingAllChannels
{
    public class SendNotification
    {
        private readonly SendSms _sendSms;
        private readonly SendEmail _sendEmail;

        public SendNotification(SendSms sendSms, SendEmail sendEmail)
        {
            _sendSms = sendSms;
            _sendEmail = sendEmail;
        }
        public void To(Guid receiverId, string text)
        {
            _sendEmail.To(receiverId, new Email(text));
            _sendSms.To(receiverId, new Sms(text));
        }
        public void To(IEnumerable<Guid> receiverIds, string text)
        {
            _sendEmail.To(receiverIds, new Email(text));
            _sendSms.To(receiverIds, new Sms(text));
        }
        
    }
}