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
        Task<bool> Update(ContactDTO obj, int id);
        Task<bool> CheckExistingEmail(string email);
    }
}
