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
    public class DepMstsController : Controller
    {
        private EmpOrgEntities1 db = new EmpOrgEntities1();

        // GET: DepMsts
        public ActionResult Index()
        {
            return View(db.DepMsts.ToList());
        }

        // GET: DepMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepMst depMst = db.DepMsts.Find(id);
            if (depMst == null)
            {
                return HttpNotFound();
            }
            return View(depMst);
        }

        // GET: DepMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dept_ID,Dept_Name")] DepMst depMst)
        {
            if (ModelState.IsValid)
            {
                db.DepMsts.Add(depMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(depMst);
        }

        // GET: DepMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepMst depMst = db.DepMsts.Find(id);
            if (depMst == null)
            {
                return HttpNotFound();
            }
            return View(depMst);
        }

        // POST: DepMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dept_ID,Dept_Name")] DepMst depMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(depMst);
        }

        // GET: DepMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepMst depMst = db.DepMsts.Find(id);
            if (depMst == null)
            {
                return HttpNotFound();
            }
            return View(depMst);
        }

        // POST: DepMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepMst depMst = db.DepMsts.Find(id);
            db.DepMsts.Remove(depMst);
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
