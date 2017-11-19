using MtB.BuddyList.Entities;
using MtB.BuddyList.Plugins;
using System.Collections.Generic;
using System.Linq;

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

        public void New(Buddy buddy)
        {
            buddy.Position = Provider.Any()
                ? Provider.Max(b => b.Position) + 1
                : 1;
            _storeBuddies.Update(buddy);
        }

        public void Update(Buddy buddy)
        {
            _storeBuddies.Update(buddy);
        }

        public IProvideBuddies Provider { get; }
    }
}
