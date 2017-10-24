using System;
using System.Collections.Generic;
using MtB.Components.ForSendingEmail;
using MtB.Components.ForSendingSms;

namespace MtB.Infrastructure.ForCommunication
{
    public class ViaAllSupportedDevices
    {
        private readonly ViaSms _viaSms;
        private readonly ViaEmail _viaEmail;

        public ViaAllSupportedDevices(ViaSms viaSms, ViaEmail viaEmail)
        {
            _viaSms = viaSms;
            _viaEmail = viaEmail;
        }
        public void Send(Guid receiverId, string text)
        {
            _viaEmail.Send(receiverId, new Email(text));
            _viaSms.Send(receiverId, new Sms(text));
        }
        public void Send(IEnumerable<Guid> receiverIds, string text)
        {
            _viaEmail.Send(receiverIds, new Email(text));
            _viaSms.Send(receiverIds, new Sms(text));
        }
        
    }
}