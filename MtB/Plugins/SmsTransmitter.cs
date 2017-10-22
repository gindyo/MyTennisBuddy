namespace MtB.SmsComponents
{
    public interface ITransmitSms
    {
        void Transmit(Contact contact, Sms sms);
    }
}