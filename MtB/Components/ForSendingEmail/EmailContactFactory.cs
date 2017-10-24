using MtB.Entities;
using MtB.Plugins;

namespace MtB.Components.ForSendingEmail
{
    public class EmailContactFactory
    {
        private readonly ITransmitEmail _transmitEmail;

        public EmailContactFactory(ITransmitEmail transmitEmail)
        {
            _transmitEmail = transmitEmail;
        }

        public EmailContact Build(Contact contact)
        {
            return new EmailContact(contact, _transmitEmail);
        }
    }
}