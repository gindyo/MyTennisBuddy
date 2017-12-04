using System;

namespace Core.PlayInvitations
{
    public class PlayInvitation
    {
        public PlayInvitation( DateTime when )
        {
            Status =  InvitationStatus.New();
            When = when;
        }

        public InvitationStatus Status { get; set; }
        public Guid From { get; set; }
        public DateTime When { get; set; }
        public DateTime Created { get; set; }
        public Guid ExternalId { get; set; }
        public long Id { get; set; }
    }
}