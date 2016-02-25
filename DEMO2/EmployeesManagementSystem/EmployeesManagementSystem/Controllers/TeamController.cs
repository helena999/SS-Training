using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using EmployeesManagementSystem.Models;


namespace EmployeesManagementSystem.Controllers
{
    public class TeamController : Controller
    {
        EmployeesManagementEntities db = new EmployeesManagementEntities();

        // GET: Team
        public ActionResult Index()
        {
            var teams = from t in db.Teams
                            orderby t.TeamID ascending
                            select t;
            return View(teams.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            //manager names where jobPosition is equal to Project Manager
            var managerNames = from e in db.Employees.ToList()
                               where e.JobPositionID == 3
                               select new
                               {
                                   EmployeeID = e.EmployeeID,
                                   FullName = e.FirstName + " " + e.LastName
                               };

            ViewBag.ManagerID = new SelectList(managerNames, "EmployeeID", "FullName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(team);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(team);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Team team = db.Teams.Find(id);

            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        [HttpPost]
        public ActionResult Delete(int? id, Team team)
        {
            team = db.Teams.Single(t => t.TeamID == id);

            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (team == null)
                {
                    return HttpNotFound();
                }

                db.Teams.Remove(team);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Team team = db.Teams.Single(t => t.TeamID == id);

            //find the team if id is available
            if (team == null)
            {
                return HttpNotFound();
            }

            //to set the value of dropdown list to the right Manager to every team for editing
            //for drobdown list manager with irst and last name
            var managerNames = from e in db.Employees.ToList()
                               where e.JobPositionID == 3
                               select new
                               {
                                   ManagerID = e.EmployeeID,
                                   FullName = e.FirstName + " " + e.LastName
                               };

            SelectList typeListM = new SelectList(managerNames.ToList(), "ManagerID","FullName", db.Employees);
            //ViewBag.ManagerID = new SelectList(managerNames, "EmployeeID", "FullName");
            ViewData["Managers"] = typeListM;
            //ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName");
           

            return View(team);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Team team)
        {           
            team = db.Teams.Single(t => t.TeamID == id);

            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();

                RedirectToAction("Index");
            }
            return View(team);
        }

        public ActionResult Detailss(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Team team = db.Teams.Find(id);

            if (team == null)
            {
                return HttpNotFound();
            }
            IEnumerable<Employee> t = team.Employees.ToList();



            //var teamEmployees = team.Employees
            //    .Select(x => new TeamEmployees
            //    {
            //        TeamId = team.TeamID,
            //        EmployeeId = x.EmployeeID,
            //        FirstName = x.FirstName,
            //        LastName = x.LastName,
            //        JobPositionID = x.JobPosition.JobPositionID,
            //        JobPosition = x.JobPosition.Name
            //    })
            //    .OrderBy(x => x.JobPositionID)
            //    .ToList();

            //to display in view the name of the current team
            ViewBag.TeamName = team.Name;

            //return View(teamEmployees);
            return View(t);

        }

        [HttpGet]
        public ActionResult AddEmployeeToTeam(int id)
        {
            Team team = db.Teams.Find(id);

            var employees = from e in db.Employees.ToList()
                            where e.JobPositionID > 3 &&  e.ManagerID == null
                            select new
                            {
                                EmployeeID = e.EmployeeID,
                                FullNameAndPosition  = e.FirstName + " " + e.LastName + " - " +                                     e.JobPosition.Name 
                            };

            ViewBag.Employees = new SelectList(employees, "EmployeeID", "FullNameAndPosition");

            return View();
        }

        [HttpPost]
        public ActionResult AddEmployeeToTeam(int id, Employee employee)
        {
            Team team = db.Teams.Find(id);

            if (ModelState.IsValid)
            {
                team.Employees.Add(employee);
                //db.Employees.Add(employee);
                db.SaveChanges();

                return RedirectToAction("Detailss", id);
            }
            return View(employee);
        }

        public ActionResult DeleteEmployee()
        {
            return View();
        }
    }
}