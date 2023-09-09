using ContactManager.DataAccess.Data;
using ContactManager.Logger.IRepository;
using ContactManager.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Logger.Repository
{
    public class ContactManagerLoggerRepository : IContactManagerLoggerRepository
    {
        private readonly ApplicationDbContext _db;
        public ContactManagerLoggerRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        private void SaveLog(ContactManagerLogger obj)
        {
            _db.contactManagerLogger.Add(obj);
            _db.SaveChanges();
        }
        public async Task AddLog(LogImportance LogImportance, string Message)
        {
            ContactManagerLogger contactManagerLogger = new ContactManagerLogger
            {
                LogDateTime = DateTime.UtcNow,
                LogLevel = LogImportance,
                Message = Message
            };
            SaveLog(contactManagerLogger);
        }
    }
}
