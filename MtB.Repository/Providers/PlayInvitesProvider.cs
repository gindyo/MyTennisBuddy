using System;
using System.Collections.Generic;
using Core.PlayInvitations;

namespace Repository.Providers
{
    internal class PlayInvitationsProvider : IProvidePlayInvitations
    {
        private readonly MtbDbContext _mtbDbContext;

        internal PlayInvitationsProvider(MtbDbContext mtbDbContext)
        {
            _mtbDbContext = mtbDbContext;
        }

        public IEnumerable<PlayInvitation> Outbound()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayInvitation> Inbound()
        {
            throw new NotImplementedException();
        }
    }
}