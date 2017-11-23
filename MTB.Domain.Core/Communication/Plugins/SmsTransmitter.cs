using Core.Communication.Components.ForSendingSms;
using Core.Communication.Entities;

namespace Core.Communication.Plugins
{
    public interface ITransmitSms
    {
        void Transmit(Contact contact, Sms sms);
    }
}