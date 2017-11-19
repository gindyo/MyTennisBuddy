using MtB.BuddyList.Entities;

namespace MtB.BuddyList.Plugins
{
    public interface IStoreBuddies
    {
        void Save(NewBuddy buddy);
        void Update (Buddy buddy);
    }
}