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
    public class StateMstsController : Controller
    {
        private EmpOrgEntities1 db = new EmpOrgEntities1();

        // GET: StateMsts
        public ActionResult Index()
        {
            return View(db.StateMsts.ToList());
        }

        // GET: StateMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMst stateMst = db.StateMsts.Find(id);
            if (stateMst == null)
            {
                return HttpNotFound();
            }
            return View(stateMst);
        }

        // GET: StateMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StateMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StateID,State_Name")] StateMst stateMst)
        {
            if (ModelState.IsValid)
            {
                db.StateMsts.Add(stateMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stateMst);
        }

        // GET: StateMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMst stateMst = db.StateMsts.Find(id);
            if (stateMst == null)
            {
                return HttpNotFound();
            }
            return View(stateMst);
        }

        // POST: StateMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StateID,State_Name")] StateMst stateMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stateMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stateMst);
        }

        // GET: StateMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMst stateMst = db.StateMsts.Find(id);
            if (stateMst == null)
            {
                return HttpNotFound();
            }
            return View(stateMst);
        }

        // POST: StateMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StateMst stateMst = db.StateMsts.Find(id);
            db.StateMsts.Remove(stateMst);
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
