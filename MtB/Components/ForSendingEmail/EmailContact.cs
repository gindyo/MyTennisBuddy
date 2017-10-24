using System;
using MtB.Entities;
using MtB.Plugins;

namespace MtB.Components.ForSendingEmail
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
        public string Email => _contact.Email;

        public void Receive(Email email)
        {
            email = new Email(email.Text, _contact.Email);
            _transmitEmail.Transmit(_contact, email);
        }
    }
}