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
            var fullname = typeof(ReceiveEmailCapability).FullName;
            if (Type == "MtB.Communication.Components.ForSendingEmail.ReceiveEmailCapability") 
                return new ReceiveEmailCapability();
            if (Type == "MtB.Communication.Components.ForSendingEmail.ReceiveSmsCapability") 
                return new ReceiveSmsCapability();
            return null;

        }
    }
}