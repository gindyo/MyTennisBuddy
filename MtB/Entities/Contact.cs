using System;
using System.Collections.Generic;

namespace MtB.Entities
{
    public class Contact
    {
        public Contact()
        {
            ComunicationCapabilities = new List<ICapability>();
        }

        public List<ICapability> ComunicationCapabilities { get; set; }
        public Guid ExternalId { get; set; }
        public int SequnceNum { get; set; }
        public string CellPhoneNmuber { get; set; }
        public string Email { get; set; }
    }
}