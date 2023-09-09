using ContactManager.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Contact>()
                .HasIndex(c => c.email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<ContactManagerLogger> contactManagerLogger { get; set; }
    }
}
