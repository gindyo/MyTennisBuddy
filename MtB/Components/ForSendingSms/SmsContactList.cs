using System;
using System.Collections.Generic;
using System.Linq;
using MtB.Entities;

namespace MtB.Components.ForSendingSms
{
    public class SmsContactList
    {
        private readonly IQueryable<Contact> _contacts;
        private readonly SmsContactFactory _smsContactFactory;

        public SmsContactList(IQueryable<Contact> contacs, SmsContactFactory smsContactFactory)
        {
            _contacts = contacs;
            _smsContactFactory = smsContactFactory;
        }


        public IEnumerable<SmsContact> Get(IEnumerable<Guid> list)
        {
            var smsContacs = _contacts.Where(c => list.Any(id => c.ExternalId == id));
            return _smsContactFactory.Build(smsContacs);
        }

        public SmsContact Get(Guid receiverId)
        {
            var smsContact = _contacts.FirstOrDefault(c => c.ExternalId == receiverId);
            return _smsContactFactory.Build(smsContact);
        }
    }
}