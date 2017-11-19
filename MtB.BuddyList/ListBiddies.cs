using MtB.BuddyList.Entities;
using MtB.BuddyList.Plugins;
using System.Collections.Generic;

namespace MtB.BuddyList
{
    public class ListBuddies : IListBuddies
    {
        private readonly IStoreBuddies _storeBuddies;
        public ListBuddies(IProvideBuddies provider, IStoreBuddies storeBuddies)
        {
            Provider = provider;
            _storeBuddies = storeBuddies;
        }
        public IEnumerable<Buddy> All()
        {
            return Provider;
        }

        public IProvideBuddies Provider { get; }
    }
}
