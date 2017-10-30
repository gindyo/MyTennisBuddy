using System.Linq;

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
            buddy.NotificationSequenceNumber = _provideBudies.Max(b=> b.NotificationSequenceNumber) + 1;
            _storeBuddies.Save(buddy);
        }
    }
}
