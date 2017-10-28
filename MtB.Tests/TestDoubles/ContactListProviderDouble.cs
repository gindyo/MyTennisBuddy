using System;
using System.Linq;
using Moq;
using MtB.Communication.Entities;
using MtB.Communication.Plugins;

namespace MtB.Tests.TestDoubles
{
    public class ProvideContactsDouble : Mock<IProvideContacts>, IProvideContacts
    {
        private readonly IQueryable<Contact> _list;

        public ProvideContactsDouble(IQueryable<Contact> list)
        {
            _list = list;
        }

        public IQueryable<Contact> GetAll(Guid userId)
        {
            return _list;
        }
    }
}