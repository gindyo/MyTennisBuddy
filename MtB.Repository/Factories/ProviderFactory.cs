using System;
using Core.BuddyList.Plugins;
using Core.Communication.Plugins;
using Core.PlayRequests;
using Repository.Providers;

namespace Repository.Factories
{
    public class ProviderFactory
    {
        private static readonly MtbDbContext MtbDbContext = new MtbDbContext();

        public static IProvideBuddies BuildBuddyProvider(Guid userId)
        {
            return new BuddiesProvider(MtbDbContext, userId);
        }
        public static IProvidePlayRequests BuildPlayrequestsProvider(Guid userId)
        {
            return new PlayRequestsProvider(MtbDbContext);
        }
        public static IProvideContacts BuildContactsProvider(Guid userId)
        {
            return new ContactsProvider(MtbDbContext);
        }

    }
}
