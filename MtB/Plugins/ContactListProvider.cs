using System;
using System.Linq;
using MtB.Entities;
using MtB.Infrastructure;

namespace MtB.Plugins
{
   
    public interface IProvideContacts
    {
        IQueryable<Contact> GetAll(Guid userId);
    }
}