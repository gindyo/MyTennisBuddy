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

    public class AcceptedInvitationStatus : InvitationStatus
    {
        public override string ToString()
        {
            return "Accepted";
        }
    }

    public class PendingInvitationStatus : InvitationStatus
    {
        public override string ToString()
        {
            return "Pending";
        }
    }

    public class NewInvitationStatus : InvitationStatus
    {
        public override string ToString()
        {
            return "New";
        }
    }
}