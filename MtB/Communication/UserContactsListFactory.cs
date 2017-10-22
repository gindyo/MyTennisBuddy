using System;
using MtB.EmailComponents;
using MtB.SmsComponents;

namespace MtB.Communication
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
        public EmailContactList GetContactListFor(ReceiveEmail sms)
        {
            var contacs = _contactListProvider.GetAll(_userId);
            return new EmailContactList(contacs,_emailContactFactory);

        }
    }
}