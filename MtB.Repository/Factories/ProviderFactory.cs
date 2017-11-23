using System;
using Core.BuddyList.Plugins;
using Repository.Providers;

namespace Repository.Factories
{
    public class ProviderFactory
    {
        public static MtbStore MTBStore = new MtbStore();
        public static IProvideBuddies BuildBuddyProvider(Guid UserId)
        {
            return new BuddiesProvider(MTBStore, UserId);
        }
    }
}
