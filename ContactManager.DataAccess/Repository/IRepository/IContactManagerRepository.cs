using ContactManager.Models.DTO;
using ContactManager.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess.Repository.IRepository
{
    public interface IContactManagerRepository : IRepository<Contact>
    {
        //any specific method for contact manager
        Task<bool> Create(ContactDTO obj);
        Task<bool> Update(ContactDTO obj, int id);
        Task<bool> CheckExistingEmailForUpdate(string email, int id);
        Task<bool> CheckExistingEmailForCreation(string email);
    }
}
