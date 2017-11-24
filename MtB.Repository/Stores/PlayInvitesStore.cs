using System;
using Core.PlayInvitations;
using Repository.StorageRecords;

namespace Repository.Providers
{
    public class PlayInvitationsStore : IStorePlayInvitations
    {
        private MtbDbContext mtbDbContext;

        public PlayInvitationsStore(MtbDbContext mtbDbContext)
        {
            this.mtbDbContext = mtbDbContext;
        }

        public Guid Create(PlayInvitation invitation)
        {
            var newGuid = Guid.NewGuid();
            mtbDbContext.PlayInvitations.Add(new PlayInvitationRecord(invitation){ExternalId  = newGuid});
            mtbDbContext.SaveChanges();
            return newGuid;
        }

        public Guid Update(PlayInvitation invitation)
        {
            throw new NotImplementedException();
        }
    }
}