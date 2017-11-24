using System;

namespace Core.PlayInvitations
{
    public interface IStorePlayInvitations
    {
        Guid Create(PlayInvitation invitation);
        Guid Update(PlayInvitation invitation);
    }
}