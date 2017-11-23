using Core.BuddyList.Entities;

namespace Core.BuddyList
{
    public interface IAddBuddy { 
        void New(NewBuddy buddy);
        void Update(Buddy buddy);
    }
}