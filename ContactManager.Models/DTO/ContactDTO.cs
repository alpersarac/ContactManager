using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Models.DTO
{
    public class ContactDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Salutation must not be empty")]
        [MinLength(3, ErrorMessage = "Salutation must be longer than 2 characters")]
        public string salutation { get; set; }
        [Required(ErrorMessage = "First Name must not be empty")]
        [MinLength(3, ErrorMessage = "First Name must be longer than 2 characters")]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string displayName { get; set; }
        public DateTime? birthDate { get; set; }
        [Required(ErrorMessage = "Email must not be empty")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string email { get; set; }
        public string phoneNumber { get; set; }
    }
}
