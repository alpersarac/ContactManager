﻿using ContactManager.DataAccess.Data;
using ContactManager.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db= db;
            ContactManager = new ContactManagerRepository(_db);
        }
        public IContactManagerRepository ContactManager { get; private set; }

    }
}
