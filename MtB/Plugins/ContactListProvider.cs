using System;
using System.Linq;
using MtB.Entities;

namespace MtB.Plugins
{
    public interface IProvideContacts
    {
        IQueryable<Contact> GetAll(Guid userId);
    }
}