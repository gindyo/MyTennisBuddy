using MtB.BuddyList.Entities;

namespace MtB.BuddyList
{
    public interface IAddBuddy { 
        void New(NewBuddy buddy);
        void Update(Buddy buddy);
    }
}