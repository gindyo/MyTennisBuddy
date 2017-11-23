using System.Collections.Generic;
using Core.BuddyList.Entities;
using Core.BuddyList.MoveOperations;

namespace Core.BuddyList.Factories
{
    public class MoveOperationsFactory
    {
        private readonly IEnumerable<Buddy> _provideBudies;

        public MoveOperationsFactory(IEnumerable<Buddy> provideBudies)
        {
            _provideBudies =  provideBudies;
        }
        public MoveOperation GetMoveOperation(Buddy buddy, int toPosition)
        {
            if (toPosition < buddy.Position)
                return new Promote(_provideBudies , buddy, toPosition);
            return new Demote(_provideBudies , buddy, toPosition);
        }
    }
}