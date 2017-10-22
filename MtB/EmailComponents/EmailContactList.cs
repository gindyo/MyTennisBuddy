using System;
using System.Collections.Generic;
using System.Linq;

namespace MtB.EmailComponents
{
    public class EmailContactList
    {
        private readonly EmailContactFactory _emailContactFactory;

        public EmailContactList(IQueryable<Contact> contacs, EmailContactFactory emailContactFactory)
        {
            _emailContactFactory = emailContactFactory;
            Contacts = contacs.Where(c => c.ComunicationCapabilities.Any(cap=> cap is  ReceiveEmail));
        }
        private IQueryable<Contact> Contacts { get;  }
        public EmailContact Get(Guid receiverId)
        {
            var contact = Contacts.FirstOrDefault(c => c.ExternalId == receiverId);
            return (contact == null) ? null : _emailContactFactory.Build(contact);
        }

        public IEnumerable<EmailContact> Get(List<Guid> receiverIds)
        {
            return  Contacts.Where(c=> receiverIds.Contains(c.ExternalId)).AsEnumerable().Select(_emailContactFactory.Build);
        }
    }
}