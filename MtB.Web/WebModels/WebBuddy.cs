using System;
using Core.BuddyList.Entities;
using Core.CommonValueObjects;

namespace Web.WebModels
{
    public class WebBuddy
    {

        internal Buddy _buddy;
        public WebBuddy(Buddy buddy) => _buddy = buddy;
        public WebBuddy() { _buddy = new Buddy(Guid.NewGuid()); }
        public Guid externalId { get => _buddy.ExternalId; }
        public string email {
            get => _buddy.ContactInfo.Email;
            set => _buddy.ContactInfo = new ContactInfo(value, _buddy.ContactInfo.CellPhoneNumber); }


        public string cellPhoneNumber {
            get => _buddy.ContactInfo.CellPhoneNumber;
            set => _buddy.ContactInfo = new ContactInfo(_buddy.ContactInfo.Email, value);
        }


        public string firstName { get => _buddy.Name.First; set => _buddy.Name = new Name(value, _buddy.Name.Last); }

        public int position { get => _buddy.Position; set => _buddy.Position = value; }

        public static implicit operator Buddy(WebBuddy web) => web._buddy;
        public static implicit operator WebBuddy(Buddy buddy) => new WebBuddy(buddy);
    }
}
