using System.Linq;
using MtB.BuddyList.Entities;

namespace MtB.BuddyList.Plugins
{
    public interface IProvideBuddies : IQueryable<Buddy>
    {

    }
}