using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Models.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Salutation must not be empty")]
        [MinLength(3,ErrorMessage = "Salutation must be longer than 2 characters")]
        public string salutation { get; set; }

        [Required(ErrorMessage = "First Name must not be empty")]
        [MinLength(3, ErrorMessage = "First Name must be longer than 2 characters")]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string displayName { get; set; }
        public DateTime? birthDate { get; set; }
        public DateTime creationTimestamp { get; set; }
        public DateTime lastChangeTimestamp { get; set; }
        public bool notifyHasBirthdaySoon
        {
            get
            {
                if (birthDate.HasValue)
                {
                    DateTime today = DateTime.Now;
                    DateTime birthday = birthDate.Value;

                    if (birthday.AddDays(-today.Day).Day>14)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        [Required(ErrorMessage ="Email must not be empty")]
        [EmailAddress(ErrorMessage ="Invalid email address")]
        public string email { get; set; }
        public string phoneNumber { get; set; }
    }
}
