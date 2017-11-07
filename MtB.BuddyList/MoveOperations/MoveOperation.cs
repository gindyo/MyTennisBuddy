using System.Collections.Generic;
using System.Linq;
using MtB.BuddyList.Entities;

namespace MtB.BuddyList.MoveOperations
{
    public abstract class MoveOperation
    {
        protected readonly IQueryable<Buddy> ProvideBudies;
        protected readonly Buddy Buddy;
        protected readonly int ToPosition;
        public List<Buddy> Affected;
        public abstract void Execute();

        protected MoveOperation(IQueryable<Buddy> provideBudies, Buddy buddy, int toPosition)
        {
            ProvideBudies = provideBudies;
            Buddy = buddy;
            ToPosition = toPosition;
        }
    }
}