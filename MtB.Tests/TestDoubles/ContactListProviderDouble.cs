using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using MtB.Communication.Entities;
using MtB.Communication.Plugins;

namespace MtB.Tests.Communication.TestDoubles
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

        public IEnumerator<Contact> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType { get; }
        public Expression Expression { get; }
        public IQueryProvider Provider { get; }
    }
}