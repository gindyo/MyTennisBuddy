using System.Linq;
using MtB.BuddyList.Entities;
using MtB.BuddyList.MoveOperations;
using System.Collections.Generic;

namespace MtB.BuddyList.Factories
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