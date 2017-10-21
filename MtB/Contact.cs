using System;
using System.Collections.Generic;

namespace MtB
{
    public class Contact
    {
        public Contact()
        {
            ContactPreferences = new List<IContactPreference>();
        }
        public List<IContactPreference> ContactPreferences { get; set; }
        public Guid ExternalId { get; set; }
        public int SequnceNum { get; set; }
    }
}