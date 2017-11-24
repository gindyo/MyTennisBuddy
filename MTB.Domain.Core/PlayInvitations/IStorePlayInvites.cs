using System;

namespace Core.PlayInvitations
{
    public interface IStorePlayInvitations
    {
        Guid Create();
        Guid Update();
    }
}