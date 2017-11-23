using System;

namespace Core.PlayRequests
{
    public class PlayRequest
    {
        public PlayRequest(Guid from, DateTime when )
        {
            Status =  RequestStatus.New();
            From = from;
            When = when;
        }

        public RequestStatus Status { get; set; }
        public Guid From { get; set; }
        public DateTime When { get; set; }
    }
}