using System;

namespace MtB.EmailComponents
{
    public class EmailTransmitter: IEmailTransmitter
    {
        public void Transmit(Contact contact, Email email)
        {
            throw new NotImplementedException();
        }
    }

    public interface IEmailTransmitter
    {
        void Transmit(Contact contact, Email email);
    }
}