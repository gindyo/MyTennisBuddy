using MtB.Communication;
using MtB.EmailComponents;

namespace MtB
{
    public interface ITransmitMessage
    {
        void Transmit(Contact contact, Email email);
    }
}