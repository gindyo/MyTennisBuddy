using System;
using Core.PlayInvitations;

namespace Web.WebModels
{
    public class WebPlayInvitation
    {
        private readonly PlayInvitation _invitation;

        public WebPlayInvitation(PlayInvitation invitation) => _invitation = invitation;
        public WebPlayInvitation() { _invitation = new PlayInvitation( DateTime.MinValue);}
        public string date
        {
            get => _invitation.When.Date.ToString("yy-MMM-dd ddd");
            set => _invitation.When = DateTime.Parse(value) + _invitation.When.TimeOfDay;
        }
        public string time
        {
            get => _invitation.When.TimeOfDay.ToString("g");
            set
            {
                var dt = _invitation.When.Date + TimeSpan.Parse(value);
                _invitation.When = dt;
            }
        }

        public Guid externalId
        {
            get => _invitation.ExternalId;
            set => _invitation.ExternalId = value;
        }

        public string status
        {
            get => _invitation.Status.ToString();
            set => _invitation.Status = InvitationStatus.New(value);
        }



        public static implicit operator PlayInvitation(WebPlayInvitation invitation)
        {
            return invitation._invitation;
        }

    }
}