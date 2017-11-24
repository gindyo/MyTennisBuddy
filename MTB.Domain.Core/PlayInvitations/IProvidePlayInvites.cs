using System.Collections.Generic;

namespace Core.PlayInvitations
{
    public interface IProvidePlayInvitations
    {
        IEnumerable<PlayInvitation> Outbound();
        IEnumerable<PlayInvitation> Inbound();
    }
}