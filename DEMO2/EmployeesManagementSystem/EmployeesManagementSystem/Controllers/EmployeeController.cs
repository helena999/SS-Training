using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeesManagementEntities db = new EmployeesManagementEntities();

        // GET: Employee
        public ActionResult Index()
        {
            //employees list order by job Position DESC
            var employees = from e in db.Employees 
                            orderby e.JobPositionID ascending 
                            select e;

            return View(employees.ToList());

        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.JobPositionID = new SelectList(db.JobPositions, "JobPositionID", "Name");
            ViewBag.TownID = new SelectList(db.Workplaces, "TownID", "Name");

            //for drobdown list manager with irst and last name
            var managerNames = from e in db.Employees.ToList()
                               select new
                               {
                                   EmployeeID = e.EmployeeID,
                                   FullName = e.FirstName + " " + e.LastName
                               };

            ViewBag.ManagerID = new SelectList(managerNames, "EmployeeID", "FullName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = db.Employees.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            //Employee employee = db.Employees.Find(id);
            Employee employee = db.Employees.Single(emp => emp.EmployeeID == id);

            //find the employee if id is available
            if (employee == null)
            {
                return HttpNotFound();
            }

            //to set the value of dropdown list to the right JopPosition, Workplace and Manager to every employee for editing
            //ViewBag.JobPositionID = new SelectList(db.JobPositions, "JobPositionID", "Name", employee.JobPositionID);
            SelectList typelistJP = new SelectList(db.JobPositions.ToList(), "JobPositionID", "Name", db.JobPositions);
            ViewData["JobPositions"] = typelistJP;


            //ViewBag.TownID = new SelectList(db.Workplaces, "TownID", "Name", employee.TownID);
            SelectList typelistWP = new SelectList(db.Workplaces.ToList(), "TownID", "Name", db.Workplaces);
            ViewData["Workplaces"] = typelistWP;

            //for drobdown list manager with irst and last name
            var managerNames = from e in db.Employees.ToList()
                               select new
                               {
                                   EmployeeID = e.EmployeeID,
                                   FullName = e.FirstName + " " + e.LastName
                               };

            //ViewBag.ManagerID = new SelectList(managerNames, "EmployeeID", "FullName", employee.ManagerID);
            SelectList typeListM = new SelectList(managerNames.ToList(), "EmployeeID", "FullName", db.Employees);
            ViewData["Managers"] = typeListM;

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = db.Employees.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int? id, Employee employee)
        {
            //employee = new Employee();
            employee = db.Employees.Single(emp => emp.EmployeeID == id);

            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

               // employee = db.Employees.Find(id);
               
                if (employee == null)
                {
                    return HttpNotFound();
                }

                db.Employees.Remove(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        //public JsonResult CheckIfEmailExist(string Email)
        //{
        //    var result = true;
        //    var user = db.Employees.Where(x => x.Email == Email).FirstOrDefault();

        //    if (user != null)
        //    {
        //        result = false;
        //    }

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}