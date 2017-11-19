using MtB.BuddyList;
using MtB.BuddyList.Entities;
using MtB.BuddyList.Plugins;
using System.Collections.Generic;
using System.Linq;
public class AddBuddy : IAddBuddy
    {
        private readonly IStoreBuddies _storeBuddies;
        private readonly IEnumerable<Buddy> _provideBudies;

        public AddBuddy(IStoreBuddies storeBuddies, IEnumerable<Buddy> provideBudies)
        {
            _storeBuddies = storeBuddies;
            _provideBudies = provideBudies;
        }

        public void New(NewBuddy buddy)
        {
            buddy.Position = _provideBudies.Count() + 1;
            _storeBuddies.Save(buddy);
        }
        public void Update(Buddy buddy)
    {

    }
    }
