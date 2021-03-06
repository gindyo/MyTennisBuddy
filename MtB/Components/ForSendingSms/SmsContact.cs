﻿using System;
using MtB.Communication.Entities;
using MtB.Communication.Plugins;

namespace MtB.Communication.Components.ForSendingSms
{
    public class SmsContact
    {
        private readonly ITransmitSms _smsTransmitterObject;
        private readonly Contact _contact;

        public SmsContact(Contact contact, ITransmitSms smsTransmitter)
        {
            _contact = contact;
            _smsTransmitterObject = smsTransmitter;
        }

        public Guid ExternalId => _contact.ExternalId;
        public int SequenceNum => _contact.NotificationSequenceNumber;

        public void Receive(Sms sms)
        {
            _smsTransmitterObject.Transmit(_contact, sms);
        }
    }
}