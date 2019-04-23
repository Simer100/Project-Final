using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmpOrgWeb.Models;

namespace EmpOrgWeb.Controllers
{
    public class EmployeeMstsController : Controller
    {
        private EmpOrgEntities1 db = new EmpOrgEntities1();

        // GET: EmployeeMsts
        public ActionResult Index()
        {
            return View(db.EmployeeMsts.ToList());
        }

        public ActionResult Export()
        {
            
            DataTable dt = ToDataTable(db.EmployeeMsts.ToList());
            if (dt.Rows.Count > 0)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                ds.Tables[0].Columns.Remove("EmployeeID");
                ds.Tables[0].Columns.Remove("Image");

                System.Web.UI.WebControls.GridView gv = new System.Web.UI.WebControls.GridView();
                gv.DataSource = ds;
                gv.DataBind();
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=outage_manager.xls");
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";

                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                gv.HeaderRow.Style.Add("background-color", "#92D050");

                Table table = new Table();

                TableRow title = new TableRow();
                title.BackColor = Color.Gray;

                TableCell titlecell = new TableCell();
                titlecell.ColumnSpan = 9;//Should span across all columns
                titlecell.HorizontalAlign = HorizontalAlign.Left;
                titlecell.RowSpan = 2;


                Label lbl = new Label();
                lbl.Text = "Employee Details";
                lbl.Style.Add("font-size", "medium");
                lbl.Style.Add("font-family", "Arial");
                lbl.Style.Add("font-weight", "bold");

                titlecell.Controls.Add(lbl);
                title.Cells.Add(titlecell);
                table.Rows.Add(title);
                table.RenderControl(htw);

                gv.RenderControl(htw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            return RedirectToAction("Index");
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        // GET: EmployeeMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeMst employeeMst = db.EmployeeMsts.Find(id);
            if (employeeMst == null)
            {
                return HttpNotFound();
            }
            return View(employeeMst);
        }

        // GET: EmployeeMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeMst employeeMst, HttpPostedFileBase file)
        {
            if (file == null)
            {
                ViewBag.ACT = "ERR";
                ViewBag.Error = "Kindly Upload Image";
                return View();
            }

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = Path.Combine(Server.MapPath("~/EmpImages"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    employeeMst.Image = Path.GetFileName(file.FileName);
                }


                db.EmployeeMsts.Add(employeeMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeMst);
        }

        // GET: EmployeeMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeMst employeeMst = db.EmployeeMsts.Find(id);
            employeeMst.Gender = employeeMst.Gender.Trim();
            if (employeeMst == null)
            {
                return HttpNotFound();
            }
            return View(employeeMst);
        }

        // POST: EmployeeMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeMst employeeMst, HttpPostedFileBase file)
        {
            if (file == null)
            {
                ViewBag.ACT = "ERR";
                ViewBag.Error = "Kindly Upload Image";
                return View();
            }
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = Path.Combine(Server.MapPath("~/EmpImages"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    employeeMst.Image = Path.GetFileName(file.FileName);
                }
                db.Entry(employeeMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeMst);
        }

        // GET: EmployeeMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeMst employeeMst = db.EmployeeMsts.Find(id);
            if (employeeMst == null)
            {
                return HttpNotFound();
            }
            return View(employeeMst);
        }

        // POST: EmployeeMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeMst employeeMst = db.EmployeeMsts.Find(id);
            db.EmployeeMsts.Remove(employeeMst);
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
        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = Path.Combine(Server.MapPath("~/EmpImages"), Path.GetFileName(ImageName));
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }

    }
}
