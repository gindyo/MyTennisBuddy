using System.Collections.Generic;
using System.Linq;
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
            return _mtbDbContext.PlayInvitations.Select(p=>(PlayInvitation)p);
        }

        public IEnumerable<PlayInvitation> Inbound()
        {
            return _mtbDbContext.PlayInvitations.Select(p=>(PlayInvitation)p);
        }
    }
}