using System.Collections.Generic;

namespace MtB.PlayRequests
{
    public interface IProvidePlayRequests
    {
        IEnumerable<PlayRequest> Outbound();
        IEnumerable<PlayRequest> Inbound();
    }
}