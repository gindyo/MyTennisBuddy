using System;

namespace MtB
{
    public class EmailContact
    {
        private readonly Contact _contact;
        private readonly ITransmitEmail _emailTransmitter;

        public EmailContact(Contact contact, ITransmitEmail emailTransmitter)
        {
            _contact = contact;
            _emailTransmitter = emailTransmitter;
        }

        public Guid ExternalId => _contact.ExternalId;
        public int SequenceNum => _contact.SequnceNum;
        public void ReceiveEmail(Email email) => _emailTransmitter.Transmit(_contact, email);
    }
}