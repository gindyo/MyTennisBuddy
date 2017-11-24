using System;
using Core.PlayInvitations;

namespace Repository.StorageRecords
{
    public class PlayInvitationRecord
    {
        public PlayInvitationRecord(PlayInvitation invitation)
        {
            Id = invitation.Id;
            ExternalId = invitation.ExternalId;
            When = invitation.When;
            From = invitation.From;
            Created = invitation.Created;
        }

        public long Id { get; set; }
        public DateTime Created { get; set; }
        public Guid From { get; set; }
        public DateTime When { get; set; }
        public Guid ExternalId { get; set; }
    }
}