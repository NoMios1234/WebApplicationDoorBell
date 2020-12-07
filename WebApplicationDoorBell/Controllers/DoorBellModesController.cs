using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationDoorBell.Models;

namespace WebApplicationDoorBell.Controllers
{
    public class DoorBellModesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DoorBellModes
        public ActionResult Index()
        {
            return View(db.doorBellModes.ToList());
        }
        [HttpGet]
        public JsonResult CheckNameMode(string name)
        {
            var res = !(name == "123");
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        // GET: DoorBellModes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoorBellMode doorBellMode = db.doorBellModes.Find(id);
            if (doorBellMode == null)
            {
                return HttpNotFound();
            }
            return View(doorBellMode);
        }

        // GET: DoorBellModes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoorBellModes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameMode,Description")] DoorBellMode doorBellMode)
        {
            if (ModelState.IsValid)
            {
                db.doorBellModes.Add(doorBellMode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doorBellMode);
        }

        // GET: DoorBellModes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoorBellMode doorBellMode = db.doorBellModes.Find(id);
            if (doorBellMode == null)
            {
                return HttpNotFound();
            }
            return View(doorBellMode);
        }

        // POST: DoorBellModes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameMode,Description")] DoorBellMode doorBellMode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doorBellMode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doorBellMode);
        }

        // GET: DoorBellModes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoorBellMode doorBellMode = db.doorBellModes.Find(id);
            if (doorBellMode == null)
            {
                return HttpNotFound();
            }
            return View(doorBellMode);
        }

        // POST: DoorBellModes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoorBellMode doorBellMode = db.doorBellModes.Find(id);
            db.doorBellModes.Remove(doorBellMode);
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
