using System;
using System.Collections.Generic;
using Core.PlayRequests;

namespace Repository.Providers
{
    public class PlayRequestsProvider : IProvidePlayRequests
    {
        public IEnumerable<PlayRequest> Outbound()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayRequest> Inbound()
        {
            throw new NotImplementedException();
        }
    }
}