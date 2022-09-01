using AssignmentDept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDept.Repository
{
    public class EmployeeRepo : IEmployee
    {
        private readonly EmployeeContext db;

        public EmployeeRepo(EmployeeContext db)
        {
            this.db = db;
        }
        public bool AddDepartment(Department d)
        {
            db.Departments.Add(d);
            int id = db.SaveChanges();
            if (id > 0)
            {
                return true;
            }
            return false;
        }

        public bool AddEmployee(Employee e)
        {
            db.employees.Add(e);
            int id = db.SaveChanges();
            if (id > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteDepartment(int id)
        {
            var ar = db.Departments.Where(x => x.Dept_id == id).FirstOrDefault();
            if (ar != null)
            {
                db.Departments.Remove(ar);
                int num=db.SaveChanges();
                if (num > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DeleteEmployee(int id)
        {
            var ar = db.employees.Where(x => x.Empid == id).FirstOrDefault(); ;
            if (ar != null)
            {
                db.employees.Remove(ar);
                int num = db.SaveChanges();
                if (num > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool EditDepertment(Department d)
        {
            db.Departments.Update(d);
            int num = db.SaveChanges();
            if (num > 0)
            {
                return true;
            }
            return false;
        }

        public bool EditEmployee(Employee e)
        {
            db.employees.Update(e);
            int num = db.SaveChanges();
            if (num > 0)
            {
                return true;
            }
            return false;
        }

        public List<Department> GetAllDepartment()
        {
            var ar = db.Departments.ToList();
            return ar;
        }

        public List<Employee> GetAllEmployees()
        {
            var ar = db.employees.ToList();
            return ar;
        }

        public Department getDepartment(int id)
        {
            var ar = db.Departments.Where(x => x.Dept_id == id).FirstOrDefault();
            


                return ar;
            
        }

        public List<Department> GetDept()
        {
            List<Department> depList = new List<Department>();
            depList = db.Departments.ToList();
            depList.Insert(0, new Department { Dept_id = 0, Dept_Name = "Please Select" });
            return depList;

        }

        public Employee GetEmployee(int id)
        {
            var ar = db.employees.Where(x => x.Empid == id).FirstOrDefault();
            return ar;
        }
    }
}
