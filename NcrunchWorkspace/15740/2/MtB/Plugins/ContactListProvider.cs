using System;
using System.Linq;
using MtB.Communication.Entities;

namespace MtB.Communication.Plugins
{
    public interface IProvideContacts : IQueryable<Contact>
    {
        IQueryable<Contact> GetAll(Guid userId);
    }
}