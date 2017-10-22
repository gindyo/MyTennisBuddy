using MtB.EmailComponents;
using MtB.Entities;

namespace MtB.Plugins
{
    public interface ITransmitEmail
    {
        void Transmit(Contact contact, Email email);
    }
}