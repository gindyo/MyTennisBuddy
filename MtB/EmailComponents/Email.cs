using MtB.Entities;
using MtB.Infrastructure;

namespace MtB.EmailComponents
{
    public interface ITransmitNotification
    {
        void Transmit(Contact contact, Email email);
    }
    public struct Email
    {
        private readonly string _text;

        public Email(string text)
        {
            _text = text;
        }
    }
}