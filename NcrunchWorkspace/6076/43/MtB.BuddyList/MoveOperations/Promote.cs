using System;
using System.Linq;
using MtB.BuddyList.Entities;
using System.Collections.Generic;

namespace MtB.BuddyList.MoveOperations
{
    public class Promote : MoveOperation
    {
        public Promote(IEnumerable<Buddy> provideBudies, Buddy buddy, int toPosition) : base(provideBudies, buddy, toPosition)
        {
            if(toPosition< 1)
                throw new ArgumentException("Destination position must be greater then 0");
            if(buddy.Position < toPosition)
                throw new ArgumentException("Destination position must be a smaller number  then current position");
        }            

        public override void Execute() 
        {
            Affected =ProvideBudies.Where(b => Enumerable.Range(ToPosition,Buddy.Position ).Contains(b.Position)).ToList();
            foreach (var b in Affected) { b.Position +=1; }
            Buddy.Position = ToPosition;
        }
    }
}