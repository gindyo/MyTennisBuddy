using System;
using MtB.EmailComponents;
using MtB.Entities;
using MtB.Plugins;
using MtB.SmsComponents;

namespace MtB.Infrastructure
{
    public class UserContactsListFactory
    {
        private readonly EmailContactFactory _emailContactFactory;
        private readonly IProvideContacts _provideContacts;
        private readonly SmsContactFactory _smsContactFactory;
        private readonly Guid _userId;

        public UserContactsListFactory(IProvideContacts provideContacts, EmailContactFactory emailContactFactory,
            SmsContactFactory smsContactFactory, Guid userId)
        {
            _provideContacts = provideContacts;
            _emailContactFactory = emailContactFactory;
            _smsContactFactory = smsContactFactory;
            _userId = userId;
        }

        public SmsContactList GetContactListFor(ReceiveSmsCapability receiveSmsCapability)
        {
            var contacs = _provideContacts.GetAll(_userId);
            return new SmsContactList(contacs, _smsContactFactory);
        }

        public EmailContactList GetContactListFor(ReceiveEmailCapability sms)
        {
            var contacs = _provideContacts.GetAll(_userId);
            return new EmailContactList(contacs, _emailContactFactory);
        }
    }
}