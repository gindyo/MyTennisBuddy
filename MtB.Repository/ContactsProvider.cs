using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MtB.Communication.Entities;
using MtB.Communication.Plugins;

namespace MtB.Repository
{
    public class ContactsProvider : IProvideContacts
    {
        private readonly FriendsProvider _friendsProvider;

        public ContactsProvider(FriendsProvider friendsProvider)
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