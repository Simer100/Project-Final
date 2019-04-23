using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmpOrgWeb.Models;

namespace EmpOrgWeb.Controllers
{
    public class EnrollmentsController : Controller
    {
        private EmpOrgEntities1 db = new EmpOrgEntities1();

        // GET: Enrollments
        public ActionResult Index()
        {
            var enrollments = db.Enrollments.Include(e => e.DepMst).Include(e => e.EmployeeMst).Include(e => e.StateMst);
            return View(enrollments.ToList());
        }

        // GET: Enrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollments/Create
        public ActionResult Create()
        {
            ViewBag.Dept_ID = new SelectList(db.DepMsts, "Dept_ID", "Dept_Name");
            ViewBag.EmployeeID = new SelectList(db.EmployeeMsts, "EmployeeID", "FirstName");
            ViewBag.StateID = new SelectList(db.StateMsts, "StateID", "State_Name");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentID,Salary,Dept_ID,EmployeeID,StateID")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dept_ID = new SelectList(db.DepMsts, "Dept_ID", "Dept_Name", enrollment.Dept_ID);
            ViewBag.EmployeeID = new SelectList(db.EmployeeMsts, "EmployeeID", "FirstName", enrollment.EmployeeID);
            ViewBag.StateID = new SelectList(db.StateMsts, "StateID", "State_Name", enrollment.StateID);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dept_ID = new SelectList(db.DepMsts, "Dept_ID", "Dept_Name", enrollment.Dept_ID);
            ViewBag.EmployeeID = new SelectList(db.EmployeeMsts, "EmployeeID", "FirstName", enrollment.EmployeeID);
            ViewBag.StateID = new SelectList(db.StateMsts, "StateID", "State_Name", enrollment.StateID);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentID,Salary,Dept_ID,EmployeeID,StateID")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dept_ID = new SelectList(db.DepMsts, "Dept_ID", "Dept_Name", enrollment.Dept_ID);
            ViewBag.EmployeeID = new SelectList(db.EmployeeMsts, "EmployeeID", "FirstName", enrollment.EmployeeID);
            ViewBag.StateID = new SelectList(db.StateMsts, "StateID", "State_Name", enrollment.StateID);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
