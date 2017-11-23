namespace Core.PlayRequests
{
    public abstract class RequestStatus
    {
        public static  RequestStatus New()
        {
            return  new NewRequestStatus();
        }
        public static RequestStatus Pending()
        {
            return  new PendingRequestStatus();
        }
        public static RequestStatus Accepted()
        {
            return  new AcceptedRequestStatus();
        }
    }

    public class AcceptedRequestStatus : RequestStatus { }
    public class PendingRequestStatus : RequestStatus { }
    public class NewRequestStatus : RequestStatus { }
}