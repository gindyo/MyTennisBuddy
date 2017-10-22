namespace MtB.EmailComponents
{
    public class EmailContactFactory
    {
        private readonly IEmailTransmitter _emailTransmitter;

        public EmailContactFactory(IEmailTransmitter emailTransmitter)
        {
            _emailTransmitter = emailTransmitter;
        }

        public EmailContact Build(Contact contact)
        {
            return new EmailContact(contact, _emailTransmitter);
        }
    }
}