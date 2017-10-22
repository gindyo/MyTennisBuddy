using System;

namespace MtB.EmailComponents
{
    public class EmailContact
    {
        private readonly Contact _contact;
        private readonly ITransmitEmail _transmitEmail;

        public EmailContact(Contact contact, ITransmitEmail transmitEmail)
        {
            _contact = contact;
            _transmitEmail = transmitEmail;
        }

        public Guid ExternalId => _contact.ExternalId;
        public int SequenceNum => _contact.SequnceNum;
        public void ReceiveEmail(Email email) => _transmitEmail.Transmit(_contact, email);
    }
}