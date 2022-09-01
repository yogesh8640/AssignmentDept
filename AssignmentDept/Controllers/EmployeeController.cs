using AssignmentDept.Models;
using AssignmentDept.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDept.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee employees;

        public EmployeeController(IEmployee employees)
        {
            this.employees = employees;
        }
        public IActionResult Index()
        {
            var data = employees.GetAllEmployees();
            return View(data);
        }
        public IActionResult Create()
        {
            //List<Department> depList = new List<Department>();
            //depList = db.Departments.ToList();
            //depList.Insert(0, new Department { Dept_id = 0, Dept_Name = "Please Select" });

            ViewBag.DepList = employees.GetDept();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee e)
        {
            if (ModelState.IsValid)
            {
                if (employees.AddEmployee(e))
                {
                    string message = "Congrats! Employee Added Successfully!!";
                    TempData["msg"] = "<div class='alert alert-success alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Success!</ strong > " + message + "</a>.</div>";


                    return RedirectToAction("Index");
                }
            }
            else
            {
                string message = "Enter Correct Data!";
                TempData["error"]= "<div class='alert alert-danger alert-dismissible' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Error!</ strong > " + message + "</a>.</div>";
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            var data = employees.GetEmployee(id);
            var ar = employees.getDepartment(data.Dept_id);
            if (ar != null)
            {
                ViewBag.dept = ar.Dept_Name;
            }
            return View(data);
        }
        public IActionResult Edit(int id)
        {
            var data = employees.GetEmployee(id);
            ViewBag.DepList = employees.GetDept();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            if (ModelState.IsValid)
            {
                if (employees.EditEmployee(e))
                {
                    string message = "Employee Details Updated!!!";
                    TempData["msg"] = "<div class='alert alert-success alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Success!</ strong > " + message + "</a>.</div>";

                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (employees.DeleteEmployee(id))
            {
                string message = "Employee Deleted!!!";
                TempData["msg"] = "<div class='alert alert-success alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Success!</ strong > " + message + "</a>.</div>";

                return RedirectToAction("Index");
            }
            return View("Index");
        }

    }
}
