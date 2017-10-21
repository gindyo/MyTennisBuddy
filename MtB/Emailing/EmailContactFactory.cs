using System;

namespace MtB
{
    public class EmailContactFactory
    {
        private readonly ITransmitEmail _emailTransmitter;

        public EmailContactFactory(ITransmitEmail emailTransmitter)
        {
            _emailTransmitter = emailTransmitter;
        }

        public EmailContact Build(Contact contact)
        {
            return new EmailContact(contact, _emailTransmitter);
        }
    }
}