﻿using MtB.BuddyList.Entities;
using System.Collections.Generic;

namespace MtB.BuddyList
{
    public interface IListBuddies
    {
        IEnumerable<Buddy> All();
    }
}