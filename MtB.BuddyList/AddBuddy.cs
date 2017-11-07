using System.Linq;
using MtB.BuddyList.Entities;
using MtB.BuddyList.Plugins;

namespace MtB.BuddyList
{
    public class AddBuddy
    {
        private readonly IStoreBuddies _storeBuddies;
        private readonly IQueryable<Buddy> _provideBudies;

        public AddBuddy(IStoreBuddies storeBuddies, IQueryable<Buddy> provideBudies)
        {
            _storeBuddies = storeBuddies;
            _provideBudies = provideBudies;
        }

        public void New(Buddy buddy)
        {
            buddy.Position = _provideBudies.Max(b=> b.Position) + 1;
            _storeBuddies.Save(buddy);
        }
    }
}
