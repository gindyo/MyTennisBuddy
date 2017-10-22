using System;
using MtB.Communication;
using MtB.EmailComponents;
using MtB.Plugins;

namespace MtB.SmsComponents
{
    public class SmsContact
    {
        private Contact _contact;
        private readonly ITransmitSms _smsTransmitterObject;

        public SmsContact(Contact contact, ITransmitSms smsTransmitter)
        {
            _contact = contact;
            _smsTransmitterObject = smsTransmitter;
        }

        public Guid ExternalId => _contact.ExternalId;
        public int SequenceNum => _contact.SequnceNum;
        public void Receive(Sms sms) => _smsTransmitterObject.Transmit(_contact, sms);
    }
}