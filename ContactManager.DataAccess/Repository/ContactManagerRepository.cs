using ContactManager.DataAccess.Data;
using ContactManager.DataAccess.Repository.IRepository;
using ContactManager.Models.DTO;
using ContactManager.Models.Models;
using Microsoft.EntityFrameworkCore;
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

        public ContactManagerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> CheckExistingEmailForCreation(string email)
        {
            bool isEmailExists = _db.contacts.Any(x => x.email.Equals(email));

            return isEmailExists;
        }

        public async Task<bool> CheckExistingEmailForUpdate(string email,int id)
        {
            bool isEmailExists = _db.contacts.Any(x => x.email.Equals(email)&& x.Id!=id);

            return isEmailExists;
        }

        public async Task<bool> Create(ContactDTO obj)
        {
            try
            {
                Contact contact = new Contact
                {
                    salutation = obj.salutation,
                    firstName = obj.firstName,
                    lastName = obj.lastName,
                    displayName = obj.displayName,
                    birthDate = obj.birthDate,
                    phoneNumber = obj.phoneNumber,
                    email = obj.email,
                    creationTimestamp = DateTime.UtcNow,
                    lastChangeTimestamp = DateTime.UtcNow
                };
                _db.contacts.Add(contact);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

            
        }

        public async Task<bool> Update(ContactDTO obj, int id)
        {
            try
            {
                Contact contact = await _db.contacts.FindAsync(id);
                if (contact != null)
                {
                    contact.email = obj.email;
                    contact.phoneNumber = obj.phoneNumber;
                    contact.birthDate = obj.birthDate;
                    contact.displayName = obj.displayName;
                    contact.firstName = obj.firstName;
                    contact.lastName = obj.lastName;
                    contact.salutation = obj.salutation;
                    contact.lastChangeTimestamp = DateTime.UtcNow;
                    await _db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
