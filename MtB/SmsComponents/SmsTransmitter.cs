namespace MtB.SmsComponents
{
    public interface ITransmitSms
    {
        void Transmit(Contact contact, Sms sms);
    }

    public class SmsTransmitter : ITransmitSms
    {
        public void Transmit(Contact contact, Sms sms)
        {
        }
    }
}