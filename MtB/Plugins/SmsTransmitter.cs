using MtB.Communication;
using MtB.SmsComponents;

namespace MtB.Plugins
{
    public interface ITransmitSms
    {
        void Transmit(Contact contact, Sms sms);
    }
}