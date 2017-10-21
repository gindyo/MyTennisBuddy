using System;

namespace MtB
{
    public class EmailTransmitter: ITransmitMessage

    {

    internal void Transmit(Contact contact, string message)
    {
        throw new NotImplementedException();
    }

        public void Transmit(Contact contact, Email email)
        {
            throw new NotImplementedException();
        }
    }
}