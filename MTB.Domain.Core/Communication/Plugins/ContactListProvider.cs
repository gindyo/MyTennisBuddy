using System;
using System.Linq;
using Core.Communication.Entities;

namespace Core.Communication.Plugins
{
    public interface IProvideContacts : IQueryable<Contact>
    {
        IQueryable<Contact> GetAll(Guid userId);
    }
}