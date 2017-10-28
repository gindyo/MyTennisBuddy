using MtB.Communication.Components.ForSendingEmail;
using MtB.Communication.Entities;

namespace MtB.Communication.Plugins
{
    public interface ITransmitEmail
    {
        void Transmit(Contact contact, Email email);
    }
}