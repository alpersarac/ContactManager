using ContactManager.DataAccess.Data;
using ContactManager.DataAccess.Repository.IRepository;
using ContactManager.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess.Repository
{
    public class ContactManagerRepository : Repository<Contact>, IContactManagerRepository
    {
        private ApplicationDbContext _db;
        
        public ContactManagerRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

    }
}
