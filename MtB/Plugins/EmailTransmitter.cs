using MtB.Communication;
using MtB.EmailComponents;

namespace MtB.Plugins
{
    public interface ITransmitEmail
    {
        void Transmit(Contact contact, Email email);
    }
}