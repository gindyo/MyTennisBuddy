using System;

namespace MtB
{
    public class UserContactsListFactory
    {
        private readonly ContactListProvider _contactListProvider;
        private readonly EmailContactFactory _emailContactFactory;
        private readonly Guid _userId;

        public UserContactsListFactory(ContactListProvider contactListProvider, EmailContactFactory emailContactFactory, Guid userId)
        {
            _contactListProvider = contactListProvider;
            _emailContactFactory = emailContactFactory;
            _userId = userId;
        }

        public EmailContactList GetEmailContactList()
        {
            var contacs = _contactListProvider.GetAll(_userId);
            return new EmailContactList(contacs,_emailContactFactory);

        }
    }
}