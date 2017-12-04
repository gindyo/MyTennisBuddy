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
            Status = invitation.Status;
        }

        public static implicit operator PlayInvitation(PlayInvitationRecord r)
        {
            return new PlayInvitation(r.When){From = r.From, Created = r.Created, ExternalId = r.ExternalId, Id = r.Id, Status = r.Status};
        }

        public InvitationStatus Status { get; set; }
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public Guid From { get; set; }
        public DateTime When { get; set; }
        public Guid ExternalId { get; set; }
    }
}