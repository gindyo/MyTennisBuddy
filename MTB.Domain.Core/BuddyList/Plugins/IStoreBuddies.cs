using Core.BuddyList.Entities;

namespace Core.BuddyList.Plugins
{
    public interface IStoreBuddies
    {
        void Save(NewBuddy buddy);
        void Update (Buddy buddy);
    }
}