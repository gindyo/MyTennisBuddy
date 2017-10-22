using System;
using MtB.SmsComponents;
using MtB.EmailComponents;

namespace MtB
{
    public class UserContactsListFactory
    {
        private readonly ContactListProvider _contactListProvider;
        private readonly EmailContactFactory _emailContactFactory;
        private readonly SmsContactFactory _smsContactFactory;
        private readonly Guid _userId;

        public UserContactsListFactory(ContactListProvider contactListProvider, EmailContactFactory emailContactFactory, SmsContactFactory smsContactFactory, Guid userId)
        {
            _contactListProvider = contactListProvider;
            _emailContactFactory = emailContactFactory;
            _smsContactFactory = smsContactFactory;
            _userId = userId;
        }

        public SmsContactList GetContactListFor(ReceiveSmsCapability receiveSmsCapability)
        {
            var contacs = _contactListProvider.GetAll(_userId);
            return new SmsContactList(contacs,_smsContactFactory);
        }
        public EmailContactList GetContactListFor(EmailPreference smsPreference)
        {
            var contacs = _contactListProvider.GetAll(_userId);
            return new EmailContactList(contacs,_emailContactFactory);

        }
    }
}