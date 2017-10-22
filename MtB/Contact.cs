using System;
using System.Collections.Generic;

namespace MtB
{
    public class Contact
    {
        public Contact()
        {
            ComunicationCapabilities = new List<IContactPreference>();
        }
        public List<IContactPreference> ComunicationCapabilities { get; set; }
        public Guid ExternalId { get; set; }
        public int SequnceNum { get; set; }
        public string CellPhoneNmuber { get; set; }
        public string Email { get; set; }
    }
}