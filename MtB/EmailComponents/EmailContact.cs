using System;

namespace MtB.EmailComponents
{
    public class EmailContact
    {
        private readonly Contact _contact;
        private readonly IEmailTransmitter _emailTransmitter;

        public EmailContact(Contact contact, IEmailTransmitter emailTransmitter)
        {
            _contact = contact;
            _emailTransmitter = emailTransmitter;
        }

        public Guid ExternalId => _contact.ExternalId;
        public int SequenceNum => _contact.SequnceNum;
        public void ReceiveEmail(Email email) => _emailTransmitter.Transmit(_contact, email);
    }
}