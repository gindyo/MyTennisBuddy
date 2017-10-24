using System;
using MtB.Components.ForSendingEmail;
using MtB.Components.ForSendingSms;
using MtB.Entities;
using MtB.Plugins;

namespace MtB.Infrastructure.ForManufacturing
{
    public class UserContacts
    {
        private readonly EmailContactFactory _emailContactFactory;
        private readonly IProvideContacts _provideContacts;
        private readonly SmsContactFactory _smsContactFactory;
        private readonly Guid _userId;

        public UserContacts(IProvideContacts provideContacts, EmailContactFactory emailContactFactory,
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