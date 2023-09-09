using ContactManager.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Logger.IRepository
{
    public interface IContactManagerLoggerRepository
    {
        Task AddLog(LogImportance LogImportance, string Message);
    }
}
