using System.Linq;
using MtB.EmailComponents;

namespace MtB.Communication
{
    public class ContactListFactory
    {
        private readonly IQueryable<Contact> _contacts;
        private readonly EmailContactFactory _emailContactFactory;

        public ContactListFactory(IQueryable<Contact> contacts, EmailContactFactory emailContactFactory)
        {
            _contacts = contacts;
            _emailContactFactory = emailContactFactory;
        }

        public EmailContactList Create(EmailPreference preference)
        {
            return new EmailContactList(_contacts, _emailContactFactory);
        }
    }
}