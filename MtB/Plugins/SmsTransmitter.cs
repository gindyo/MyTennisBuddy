using MtB.Components.ForSendingSms;
using MtB.Entities;

namespace MtB.Plugins
{
    public interface ITransmitSms
    {
        void Transmit(Contact contact, Sms sms);
    }
}