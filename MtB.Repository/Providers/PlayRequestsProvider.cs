using System;
using System.Collections.Generic;
using Core.PlayRequests;

namespace Repository.Providers
{
    internal class PlayRequestsProvider : IProvidePlayRequests
    {
        private readonly MtbDbContext _mtbDbContext;

        internal PlayRequestsProvider(MtbDbContext mtbDbContext)
        {
            _mtbDbContext = mtbDbContext;
        }

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