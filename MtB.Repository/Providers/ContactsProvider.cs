using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Communication.Entities;
using Core.Communication.Plugins;
using Repository.Entities;

namespace Repository.Providers
{
    public class ContactsProvider : IProvideContacts
    {
        private readonly MtbDbContext _friendsProvider;

        public ContactsProvider(MtbDbContext friendsProvider)
        {
            _friendsProvider = friendsProvider;
        }

        public IEnumerator<Contact> GetEnumerator()
        {
            return _friendsProvider.Friends.Select(ToContact).GetEnumerator();
        }

        private Contact ToContact(Friend friend)
        {
            return friend.ToContact();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType => typeof(Contact);
        public Expression Expression => _friendsProvider.Friends.Select(f=> f.ToContact()).AsQueryable().Expression;
        public IQueryProvider Provider => _friendsProvider.Friends.Select(f => f.ToContact()).AsQueryable().Provider;
        public IQueryable<Contact> GetAll(Guid userId)
        {
            return this;
        }
    }
}