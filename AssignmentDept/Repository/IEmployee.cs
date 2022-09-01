using AssignmentDept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDept.Repository
{
    public interface IEmployee
    {
        List<Department> GetAllDepartment();
        bool AddDepartment(Department d);
        bool EditDepertment(Department d);
        Department getDepartment(int id);

        List<Department> GetDept();

        bool DeleteDepartment(int id);
        bool DeleteEmployee(int id);
        List<Employee> GetAllEmployees();
        bool AddEmployee(Employee e);
        bool EditEmployee(Employee e);
        Employee GetEmployee(int id);

    }
}
