using System;
using Core.Communication.Components.ForSendingEmail;
using Core.Communication.Components.ForSendingSms;
using Core.Communication.Plugins;

namespace Core.Communication.Factories
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

        public SmsContactList With(ReceiveSmsCapability receiveSmsCapability)
        {
            var contacs = _provideContacts.GetAll(_userId);
            return new SmsContactList(contacs, _smsContactFactory);
        }

        public EmailContactList With(ReceiveEmailCapability sms)
        {
            var contacs = _provideContacts.GetAll(_userId);
            return new EmailContactList(contacs, _emailContactFactory);
        }
    }
}