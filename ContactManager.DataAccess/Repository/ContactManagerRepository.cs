﻿using ContactManager.DataAccess.Data;
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
        
        public ContactManagerRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public async Task<bool> Update(ContactDTO obj, int id)
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
                contact.salutation= obj.salutation;
                await _db.SaveChangesAsync();
                return true;
            }
            return false;

        }
    }
}