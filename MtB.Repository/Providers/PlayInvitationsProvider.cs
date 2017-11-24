using System;
using System.Collections.Generic;
using Core.PlayInvitations;

namespace Repository.Providers
{
    public class PlayInvitationsProvider : IProvidePlayInvitations
    {
        private readonly MtbDbContext _mtbDbContext;

        public  PlayInvitationsProvider(MtbDbContext mtbDbContext)
        {
            _mtbDbContext = mtbDbContext;
        }

        public IEnumerable<PlayInvitation> Outbound()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayInvitation> Inbound()
        {
            return new List<PlayInvitation>();
        }
    }
}