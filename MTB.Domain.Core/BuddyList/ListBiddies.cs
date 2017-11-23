using System;
using System.Collections.Generic;
using System.Linq;
using Core.BuddyList.Entities;
using Core.BuddyList.Plugins;

namespace Core.BuddyList
{
    public class ListBuddies : IListBuddies
    {
        public ListBuddies(IProvideBuddies provider)
        {
            Provider = provider;
        }
        public IEnumerable<Buddy> All()
        {
            return Provider;
        }

        public Buddy Get(Guid id)
        {
            return Provider.FirstOrDefault(b => b.ExternalId == id);
        }

        public IProvideBuddies Provider { get; }
    }
}
