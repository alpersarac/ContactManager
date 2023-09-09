using ContactManager.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //generic methods
        Task<bool> Create(T obj);
        
        Task<bool> Delete(int id);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
