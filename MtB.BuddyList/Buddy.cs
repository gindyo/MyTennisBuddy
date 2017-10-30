using System;
using MtB.CommonValueObjects;

namespace MtB.BuddyList
{

    public class Buddy
    {
        public Buddy(Guid externalId) 
        {
            ExternalId = externalId;
        }
        public Guid ExternalId { get; }
        public Name Name { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public int NotificationSequenceNumber { get; set; }
        public override bool Equals(object obj)
        {
            return Equals(obj as Buddy);
        }

        protected bool Equals(Buddy other)
        {
            if (other == null)
                return false;
            return ExternalId.Equals(other.ExternalId);
        }

        public override int GetHashCode()
        {
            return ExternalId.GetHashCode();
        }
    }

}