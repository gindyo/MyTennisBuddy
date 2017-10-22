using System;
using System.Linq;

namespace MtB.Communication
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