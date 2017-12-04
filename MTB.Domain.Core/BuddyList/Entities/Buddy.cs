using System;
using Core.CommonValueObjects;

namespace Core.BuddyList.Entities
{

    public class Buddy
    {
        public Buddy(Guid externalId) 
        {
            ExternalId = externalId;
        }
        public Guid ExternalId { get; set; }
        public Name Name { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public int Position { get; set; }
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