﻿using ContactManager.DataAccess.Data;
using ContactManager.DataAccess.Repository.IRepository;
using ContactManager.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db) 
        {
            _db = db;
            this.dbSet = db.Set<T>();
        }

        public async Task Create(T obj)
        {
            dbSet.AddAsync(obj);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Update(T obj)
        {
            dbSet.Update(obj);
            await _db.SaveChangesAsync();

        }

        public async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }
    }
}
