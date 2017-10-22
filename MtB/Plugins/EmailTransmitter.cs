using System;

namespace MtB.EmailComponents
{
    public interface ITransmitEmail
    {
        void Transmit(Contact contact, Email email);
    }
}