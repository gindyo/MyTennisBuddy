using Core.Communication.Components.ForSendingEmail;
using Core.Communication.Components.ForSendingSms;
using Core.Communication.Entities;

namespace Repository.Entities
{
    public class CommunicationCapabilityRecord
    {
        public int Id { get; set; }
        public string Type { get; set; }


        public  ICapability ToICapability()
        {
            if (Type == typeof(ReceiveEmailCapability).FullName) 
                return new ReceiveEmailCapability();
            if (Type == typeof(ReceiveSmsCapability).FullName) 
                return new ReceiveSmsCapability();
            return null;

        }
    }
}