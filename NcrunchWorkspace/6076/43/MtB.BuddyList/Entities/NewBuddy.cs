using MtB.BuddyList.Entities;

namespace MtB.BuddyList
{
    public class NewBuddy 
    {
        private readonly Buddy  _buddy;
        public NewBuddy(Buddy buddy)
        {
            _buddy = buddy;
        }


        public static implicit operator Buddy(NewBuddy newBuddy){
            return newBuddy._buddy;
         }
    }
}

