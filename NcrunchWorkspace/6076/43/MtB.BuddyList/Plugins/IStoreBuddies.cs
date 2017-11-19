using System.Collections.Generic;
using MtB.BuddyList.Entities;

namespace MtB.BuddyList.Plugins
{
    public interface IStoreBuddies
    {
        void Save(NewBuddy buddy);
        void Update(Buddy buddy);
        void Save(IEnumerable<Buddy> affected);
    }
}