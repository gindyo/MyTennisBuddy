using System;
using System.Collections.Generic;
using System.Linq;
using MtB.BuddyList.Entities;
using MtB.CommonValueObjects;
using MtB.Communication.Entities;

namespace MtB.Repository.Entities
{
    public class Friend
    {
        public Friend() { }
        public Friend(Buddy buddy)
        {
            FirstName = buddy.Name.First;
            LastName = buddy.Name.Last;
            Email = buddy.ContactInfo.Email;
            CellPhoneNmuber = buddy.ContactInfo.CellPhoneNumber;
            Position = buddy.Position;
            ExternalId = buddy.ExternalId;
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CommunicationCapability> ComunicationCapabilities { get; set; }
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
    }
}