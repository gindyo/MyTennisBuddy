using MtB.Communication.Components.ForSendingSms;
using MtB.Communication.Entities;

namespace MtB.Communication.Plugins
{
    public interface ITransmitSms
    {
        void Transmit(Contact contact, Sms sms);
    }
}