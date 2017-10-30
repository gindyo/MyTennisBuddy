using MtB.Communication.Components.ForSendingEmail;
using MtB.Communication.Components.ForSendingSms;
using MtB.Communication.Entities;

namespace MtB.Repository
{
    public class CommunicationCapability
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