using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDept.Models
{
    public class Department
    {
        [Key]
        public int Dept_id { get; set; }
        [Required]
        public string Dept_Name { get; set; }
    }
}
