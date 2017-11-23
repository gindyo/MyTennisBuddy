using System;
using System.Collections.Generic;
using Core.BuddyList.Entities;

namespace Core.BuddyList
{
    public interface IListBuddies
    {
        IEnumerable<Buddy> All();
        Buddy Get(Guid id);
    }
}