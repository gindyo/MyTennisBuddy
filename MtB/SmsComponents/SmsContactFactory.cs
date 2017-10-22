using System.Collections.Generic;
using System.Linq;

namespace MtB.SmsComponents
{
    public class SmsContactFactory 
    {
        private readonly ITransmitSms _messageTarnsmitterObject;

        public SmsContactFactory(ITransmitSms messageTarnsmitterObject)
        {
            _messageTarnsmitterObject = messageTarnsmitterObject;
        }

        public IEnumerable<SmsContact> Build(IQueryable<Contact> contacts)
        {
            return contacts
                .Where(c => c.ComunicationCapabilities .Any(p => p is ReceiveSmsCapability))
                .AsEnumerable()
                .Select(Build);
        }

        public SmsContact Build(Contact smsContact)
        {
            return new SmsContact(smsContact,_messageTarnsmitterObject);
        }
    }
}