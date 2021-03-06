﻿using System;
using System.Collections.Generic;
using System.Linq;
using Core.BuddyList.Entities;
using Core.CommonValueObjects;
using Core.Communication.Entities;

namespace Repository.Entities
{
    public class BuddyRecord
    {
        public BuddyRecord() { }
        public BuddyRecord(Buddy buddy)
        {
            Update(buddy);
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CommunicationCapabilityRecord> ComunicationCapabilities { get; set; }
        public Guid ExternalId { get; set; }
        public int Position { get; set; }
        public string CellPhoneNmuber { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }

        public Buddy ToBuddy()
        {
            return new Buddy(ExternalId)
            {
                ContactInfo =  new ContactInfo(Email,CellPhoneNmuber),
                Name = new Name(FirstName, LastName),
                Position = Position
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

        public void Update(Buddy buddy)
        {
            FirstName = buddy.Name.First;
            LastName = buddy.Name.Last;
            Email = buddy.ContactInfo.Email;
            CellPhoneNmuber = buddy.ContactInfo.CellPhoneNumber;
            Position = buddy.Position;
            ExternalId = buddy.ExternalId;
        }
    }
}