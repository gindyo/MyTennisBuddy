using System;
using System.Collections.Generic;
using System.Linq;
using MtB.Entities;

namespace MtB.Infrastructure
{
    public class ContactList
    {
        protected IQueryable<Contact> Contacts;

        public virtual Contact Get(Guid receiverId)
        {
            return Contacts.FirstOrDefault(c => c.ExternalId == receiverId);
        }

        public virtual IEnumerable<Contact> Get(List<Guid> receiverIds)
        {
            return Contacts.Where(c => receiverIds.Contains(c.ExternalId)).AsEnumerable();
        }
    }
}