using System;
using System.Linq;
using MtB.BuddyList.Entities;
using System.Collections.Generic;

namespace MtB.BuddyList.MoveOperations
{
    public class Demote : MoveOperation
    {
        public Demote(IEnumerable<Buddy> provideBudies, Buddy buddy, int toPosition) : base(provideBudies, buddy, toPosition)
        {
            if (toPosition > provideBudies.OrderBy(b => b.Position).Last().Position) 
                throw new ArgumentException("Destination position can not be greater then the last existing position");
            if(toPosition < buddy.Position)
                throw new ArgumentException("Destination position can not be a smaller number then current position");

        }            
        public override void Execute()
        {
            Affected =ProvideBudies.Where(b => Enumerable.Range(Buddy.Position, ToPosition).Contains(b.Position)).ToList();
            foreach (var b in Affected) { b.Position  -= 1; }
            Buddy.Position = ToPosition;
        }
    }
}