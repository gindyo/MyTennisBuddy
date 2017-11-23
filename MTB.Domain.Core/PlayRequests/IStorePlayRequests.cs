using System;

namespace Core.PlayRequests
{
    public interface IStorePlayRequests
    {
        Guid Create();
        Guid Update();
    }
}