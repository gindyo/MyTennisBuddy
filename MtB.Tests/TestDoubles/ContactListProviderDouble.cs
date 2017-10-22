using System;
using System.Linq;
using Moq;
using MtB.Communication;

namespace MtB.Tests.TestDoubles
{
    public class ContactListProviderDouble : Mock<IContactListProvider>, IContactListProvider
    {
        private IQueryable<Contact> _list;

        public ContactListProviderDouble(IQueryable<Contact> list)
        {
            _list = list;
        }
        public IQueryable<Contact> GetAll(Guid userId)
        {
            return _list;
        }
    }
}