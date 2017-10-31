﻿using System;
using System.Collections.Generic;
using System.Linq;
using MtB.BuddyList;
using MtB.CommonValueObjects;
using MtB.Communication.Entities;

namespace MtB.Repository.Entities
{
    public class Friend
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CommunicationCapability> ComunicationCapabilities { get; set; }
        public Guid ExternalId { get; set; }
        public int NotificationSequenceNumber { get; set; }
        public string CellPhoneNmuber { get; set; }
        public string Email { get; set; }

        public Buddy ToBuddy()
        {
            return new Buddy(ExternalId)
            {
                ContactInfo =  new ContactInfo(CellPhoneNmuber, Email),
                Name = new Name(FirstName, LastName)
            };
        }
        public Contact ToContact()
        {
            return new Contact()
            {
                Name = new Name(FirstName,LastName),
                Email = Email,
                CellPhoneNmuber = CellPhoneNmuber,
                ExternalId = ExternalId,
                ComunicationCapabilities =  ComunicationCapabilities?.Select(c=>c.ToICapability()).ToList()
            };
        }
    }
}