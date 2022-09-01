using AssignmentDept.Models;
using AssignmentDept.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDept.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IEmployee employees;

        public DepartmentController(IEmployee employees)
        {
            this.employees = employees;
        }
        public IActionResult Index()
        {
            var data = employees.GetAllDepartment();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department d)
        {
            if (ModelState.IsValid)
            {
                if (employees.AddDepartment(d))
                {
                    string message = "Great! Employee Added Successfully!!";
                    TempData["msg"] = "<div class='alert alert-success alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Success!</ strong > " + message + "</a>.</div>";

                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            var data = employees.getDepartment(id);
            return View(data);
        }
        public IActionResult Edit(int id)
        {
            var data = employees.getDepartment(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Department d)
        {
            if (ModelState.IsValid)
            {
                if (employees.EditDepertment(d))
                {
                    string message = "Department Updated!!!";
                    TempData["msg"] = "<div class='alert alert-success alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Success!</ strong > " + message + "</a>.</div>";

                    return RedirectToAction("Index");
                }
            }
            return View();
        }
       
        public IActionResult Delete(int id)
        {
            if (employees.DeleteDepartment(id))
            {
                string message = "Department Deleted!!!";
                TempData["msg"] = "<div class='alert alert-success alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Success!</ strong > " + message + "</a>.</div>";

                return RedirectToAction("Index");
            }
            return View("Index");
        }

    }
}
