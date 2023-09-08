using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IContactManagerRepository ContactManager { get; }
    }
}
