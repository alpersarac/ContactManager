﻿using System;
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
        [Required(ErrorMessage = "Last Name must not be empty")]
        [MinLength(3, ErrorMessage = "Last Name must be longer than 2 characters")]
        public string lastName { get; set; }
        public string _displayName;
        public string displayName 
        {
            get
            {
                if (string.IsNullOrEmpty(_displayName))
                {
                    return $"{salutation} {firstName} {lastName}";
                }
                return _displayName ;
            }
            set
            {
                _displayName = value ;
            }

        }
        private DateTime? _birthDate;
        public DateTime? birthDate
        {
            get
            {
                if (!_birthDate.HasValue)
                {
                    return null;
                }
                return _birthDate;
            }
            set
            {
                _birthDate = value;
            }
        }

        public DateTime creationTimestamp { get; set; }
        public DateTime lastChangeTimestamp { get; set; }
        private bool _notifyHasBirthdaySoon=false;
        public bool notifyHasBirthdaySoon
        {
            get
            {
                if (birthDate.HasValue)
                {
                    DateTime today = DateTime.Now;
                    DateTime birthday = birthDate.Value;
                    DateTime birthdayForCurrentYear = new DateTime(today.Year, birthDate.Value.Month, birthDate.Value.Day);
                    var timeSpan = birthdayForCurrentYear - today;
                    if (timeSpan.Days <= 14 && timeSpan.Days >= 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            set
            {
                _notifyHasBirthdaySoon = false;
            }

        }
        [Required(ErrorMessage ="Email must not be empty")]
        [EmailAddress(ErrorMessage ="Invalid email address")]
        public string email { get; set; }
        public string phoneNumber { get; set; }
    }
}
