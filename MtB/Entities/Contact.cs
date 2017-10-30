using System;
using System.Collections.Generic;

namespace MtB.Communication.Entities
{
    public class Contact
    {
        public Contact()
        {
            ComunicationCapabilities = new List<ICapability>();
        }

        public string Name { get; set; }
        public List<ICapability> ComunicationCapabilities { get; set; }
        public Guid ExternalId { get; set; }
        public int NotificationSequenceNumber { get; set; }
        public string CellPhoneNmuber { get; set; }
        public string Email { get; set; }
    }
}