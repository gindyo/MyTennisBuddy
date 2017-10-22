using MtB.Entities;
using MtB.Infrastructure;
using MtB.Plugins;

namespace MtB.EmailComponents
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