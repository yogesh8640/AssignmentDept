using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AssignmentDept.Models
{
    
    public class Login
    {
        [Required]
        public int username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
