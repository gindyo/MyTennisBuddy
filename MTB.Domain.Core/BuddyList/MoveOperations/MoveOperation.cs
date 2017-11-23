using System.Collections.Generic;
using Core.BuddyList.Entities;

namespace Core.BuddyList.MoveOperations
{
    public abstract class MoveOperation
    {
        protected readonly IEnumerable<Buddy> ProvideBudies;
        protected readonly Buddy Buddy;
        protected readonly int ToPosition;
        public List<Buddy> Affected;
        public abstract void Execute();

        protected MoveOperation(IEnumerable<Buddy> provideBudies, Buddy buddy, int toPosition)
        {
            ProvideBudies = provideBudies;
            Buddy = buddy;
            ToPosition = toPosition;
        }
    }
}