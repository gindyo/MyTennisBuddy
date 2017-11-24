using System;
using Core.BuddyList.Plugins;
using Core.Communication.Plugins;
using Core.PlayInvitations;
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
        public static IProvidePlayInvitations BuildPlayrequestsProvider(Guid userId)
        {
            return new PlayInvitationsProvider(MtbDbContext);
        }
        public static IProvideContacts BuildContactsProvider(Guid userId)
        {
            return new ContactsProvider(MtbDbContext);
        }

    }
}
