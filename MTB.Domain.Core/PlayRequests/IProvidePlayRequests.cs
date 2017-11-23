using System.Collections.Generic;

namespace Core.PlayRequests
{
    public interface IProvidePlayRequests
    {
        IEnumerable<PlayRequest> Outbound();
        IEnumerable<PlayRequest> Inbound();
    }
}