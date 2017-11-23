using Core.Communication.Components.ForSendingEmail;
using Core.Communication.Entities;

namespace Core.Communication.Plugins
{
    public interface ITransmitEmail
    {
        void Transmit(Contact contact, Email email);
    }
}