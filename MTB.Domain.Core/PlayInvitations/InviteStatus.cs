using System;

namespace Core.PlayInvitations
{
    public abstract class InvitationStatus
    {

        public static InvitationStatus Pending()
        {
            return  new PendingInvitationStatus();
        }
        public static InvitationStatus Accepted()
        {
            return  new AcceptedInvitationStatus();
        }

        public static  InvitationStatus New()
        {
            return  new NewInvitationStatus();
        }
        public static InvitationStatus New(string value)
        {
            switch (value)
            {
                case "accepted": return Accepted();
                case "pending": return Pending();
                default:  return New();
            }
        }
    }

    public class AcceptedInvitationStatus : InvitationStatus { }
    public class PendingInvitationStatus : InvitationStatus { }
    public class NewInvitationStatus : InvitationStatus { }
}