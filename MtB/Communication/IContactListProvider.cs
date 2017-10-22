using System;
using System.Linq;

namespace MtB.Communication
{
   
    public interface IContactListProvider
    {
        IQueryable<Contact> GetAll(Guid userId);
    }
}