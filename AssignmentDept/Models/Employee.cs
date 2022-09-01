using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDept.Models
{
    public class Employee
    {
        [Key]
        public int Empid { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [ForeignKey("Department")]
        [Display(Name ="Department_id")]
        public int Dept_id { get; set; }
        [Display(Name = "Department_id")]

        public Department Department { get; set; }
    }
}
