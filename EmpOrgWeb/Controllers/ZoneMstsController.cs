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
    public class ZoneMstsController : Controller
    {
        private EmpOrgEntities db = new EmpOrgEntities();

        // GET: ZoneMsts
        public ActionResult Index()
        {
            return View(db.ZoneMsts.ToList());
        }

        // GET: ZoneMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZoneMst zoneMst = db.ZoneMsts.Find(id);
            if (zoneMst == null)
            {
                return HttpNotFound();
            }
            return View(zoneMst);
        }

        // GET: ZoneMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZoneMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZoneID,Zone_Name")] ZoneMst zoneMst)
        {
            if (ModelState.IsValid)
            {
                db.ZoneMsts.Add(zoneMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zoneMst);
        }

        // GET: ZoneMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZoneMst zoneMst = db.ZoneMsts.Find(id);
            if (zoneMst == null)
            {
                return HttpNotFound();
            }
            return View(zoneMst);
        }

        // POST: ZoneMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZoneID,Zone_Name")] ZoneMst zoneMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zoneMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zoneMst);
        }

        // GET: ZoneMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZoneMst zoneMst = db.ZoneMsts.Find(id);
            if (zoneMst == null)
            {
                return HttpNotFound();
            }
            return View(zoneMst);
        }

        // POST: ZoneMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZoneMst zoneMst = db.ZoneMsts.Find(id);
            db.ZoneMsts.Remove(zoneMst);
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
