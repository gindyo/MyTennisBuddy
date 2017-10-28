using System;
using MtB.Communication.Components.ForSendingEmail;
using MtB.Communication.Components.ForSendingSms;
using MtB.Communication.Entities;
using MtB.Communication.Plugins;

namespace MtB.Communication.Factories
{
    public class BuildUserContactList
    {
        private readonly EmailContactFactory _emailContactFactory;
        private readonly IProvideContacts _provideContacts;
        private readonly SmsContactFactory _smsContactFactory;
        private readonly Guid _userId;

        public BuildUserContactList(IProvideContacts provideContacts, EmailContactFactory emailContactFactory,
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