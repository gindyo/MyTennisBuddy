namespace Core.PlayInvitations
{
    public abstract class Invitation
    {
        public static  Invitation New()
        {
            return  new NewInvitation();
        }
        public static Invitation Pending()
        {
            return  new PendingInvitation();
        }
        public static Invitation Accepted()
        {
            return  new AcceptedInvitation();
        }
    }

    public class AcceptedInvitation : Invitation { }
    public class PendingInvitation : Invitation { }
    public class NewInvitation : Invitation { }
}