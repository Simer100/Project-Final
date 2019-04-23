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
    public class EmpAddressDetsController : Controller
    {
        private EmpOrgEntities1 db = new EmpOrgEntities1();

        // GET: EmpAddressDets
        public ActionResult Index()
        {
            var empAddressDets = db.EmpAddressDets.Include(e => e.EmployeeMst).Include(e => e.StateMst);
            return View(empAddressDets.ToList());
        }

        // GET: EmpAddressDets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpAddressDet empAddressDet = db.EmpAddressDets.Find(id);
            if (empAddressDet == null)
            {
                return HttpNotFound();
            }
            return View(empAddressDet);
        }

        // GET: EmpAddressDets/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.EmployeeMsts, "EmployeeID", "FirstName");
            ViewBag.StateID = new SelectList(db.StateMsts, "StateID", "State_Name");
            return View();
        }

        // POST: EmpAddressDets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressID,Address1,Address2,EmployeeID,StateID,PinCode")] EmpAddressDet empAddressDet)
        {
            if (ModelState.IsValid)
            {
                db.EmpAddressDets.Add(empAddressDet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.EmployeeMsts, "EmployeeID", "FirstName", empAddressDet.EmployeeID);
            ViewBag.StateID = new SelectList(db.StateMsts, "StateID", "State_Name", empAddressDet.StateID);
            return View(empAddressDet);
        }

        // GET: EmpAddressDets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpAddressDet empAddressDet = db.EmpAddressDets.Find(id);
            if (empAddressDet == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.EmployeeMsts, "EmployeeID", "FirstName", empAddressDet.EmployeeID);
            ViewBag.StateID = new SelectList(db.StateMsts, "StateID", "State_Name", empAddressDet.StateID);
            return View(empAddressDet);
        }

        // POST: EmpAddressDets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressID,Address1,Address2,EmployeeID,StateID,PinCode")] EmpAddressDet empAddressDet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empAddressDet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.EmployeeMsts, "EmployeeID", "FirstName", empAddressDet.EmployeeID);
            ViewBag.StateID = new SelectList(db.StateMsts, "StateID", "State_Name", empAddressDet.StateID);
            return View(empAddressDet);
        }

        // GET: EmpAddressDets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpAddressDet empAddressDet = db.EmpAddressDets.Find(id);
            if (empAddressDet == null)
            {
                return HttpNotFound();
            }
            return View(empAddressDet);
        }

        // POST: EmpAddressDets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpAddressDet empAddressDet = db.EmpAddressDets.Find(id);
            db.EmpAddressDets.Remove(empAddressDet);
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
