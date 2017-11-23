using System;
using Core.Communication.Entities;
using Core.Communication.Plugins;

namespace Core.Communication.Components.ForSendingEmail
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
        public int SequenceNum => _contact.NotificationSequenceNumber;
        public string Email => _contact.Email;

        public void Receive(Email email)
        {
            email = new Email(email.Text, _contact.Email);
            _transmitEmail.Transmit(_contact, email);
        }
    }
}