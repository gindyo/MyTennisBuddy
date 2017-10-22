using MtB.EmailComponents;
using MtB.Entities;
using MtB.Infrastructure;

namespace MtB.Plugins
{
    public interface ITransmitEmail
    {
        void Transmit(Contact contact, Email email);
    }
}