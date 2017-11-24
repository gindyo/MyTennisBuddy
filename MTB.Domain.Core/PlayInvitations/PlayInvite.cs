using System;

namespace Core.PlayInvitations
{
    public class PlayInvitation
    {
        public PlayInvitation(Guid from, DateTime when )
        {
            Status =  Invitation.New();
            From = from;
            When = when;
        }

        public Invitation Status { get; set; }
        public Guid From { get; set; }
        public DateTime When { get; set; }
    }
}