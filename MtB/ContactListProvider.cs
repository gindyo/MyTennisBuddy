using System;
using System.Collections.Generic;
using System.Linq;

namespace MtB
{
    public class ContactListProvider
    {
        private IQueryable<Contact> _list;

        public ContactListProvider(IQueryable<Contact> list)
        {
            _list = list;
        }
        public IQueryable<Contact> GetAll(Guid userId)
        {
            return _list;
        }
    }
}