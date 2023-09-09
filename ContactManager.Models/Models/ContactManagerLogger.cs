using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Models.Models
{
    public class ContactManagerLogger
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime LogDateTime { get; set; }
        [Required]
        public LogImportance LogLevel { get; set; }
        [Required]
        public string Message { get; set; }
    }
    public enum LogImportance
    {
        Information,
        Warning,
        Error,
        Critical
    }
}
