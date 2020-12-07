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
    public class Wi_FiController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Wi_Fi
        public ActionResult Index()
        {
            var wi_Fis = db.wi_Fis.Include(w => w.DoorBellMode);
            return View(wi_Fis.ToList());
        }

        // GET: Wi_Fi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wi_Fi wi_Fi = db.wi_Fis.Find(id);
            if (wi_Fi == null)
            {
                return HttpNotFound();
            }
            return View(wi_Fi);
        }

        // GET: Wi_Fi/Create
        public ActionResult Create()
        {
            ViewBag.DoorBellModeId = new SelectList(db.doorBellModes, "Id", "NameMode");
            return View();
        }

        // POST: Wi_Fi/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SSID,Password,Description,DoorBellModeId")] Wi_Fi wi_Fi)
        {
            if (ModelState.IsValid)
            {
                db.wi_Fis.Add(wi_Fi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoorBellModeId = new SelectList(db.doorBellModes, "Id", "NameMode", wi_Fi.DoorBellModeId);
            return View(wi_Fi);
        }

        // GET: Wi_Fi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wi_Fi wi_Fi = db.wi_Fis.Find(id);
            if (wi_Fi == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoorBellModeId = new SelectList(db.doorBellModes, "Id", "NameMode", wi_Fi.DoorBellModeId);
            return View(wi_Fi);
        }

        // POST: Wi_Fi/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SSID,Password,Description,DoorBellModeId")] Wi_Fi wi_Fi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wi_Fi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoorBellModeId = new SelectList(db.doorBellModes, "Id", "NameMode", wi_Fi.DoorBellModeId);
            return View(wi_Fi);
        }

        // GET: Wi_Fi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wi_Fi wi_Fi = db.wi_Fis.Find(id);
            if (wi_Fi == null)
            {
                return HttpNotFound();
            }
            return View(wi_Fi);
        }

        // POST: Wi_Fi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wi_Fi wi_Fi = db.wi_Fis.Find(id);
            db.wi_Fis.Remove(wi_Fi);
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
