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
    public class PlayModesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlayModes
        public ActionResult Index()
        {
            return View(db.playModes.ToList());
        }

        // GET: PlayModes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayMode playMode = db.playModes.Find(id);
            if (playMode == null)
            {
                return HttpNotFound();
            }
            return View(playMode);
        }

        // GET: PlayModes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayModes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] PlayMode playMode)
        {
            if (ModelState.IsValid)
            {
                db.playModes.Add(playMode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playMode);
        }

        // GET: PlayModes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayMode playMode = db.playModes.Find(id);
            if (playMode == null)
            {
                return HttpNotFound();
            }
            return View(playMode);
        }

        // POST: PlayModes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] PlayMode playMode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playMode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playMode);
        }

        // GET: PlayModes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayMode playMode = db.playModes.Find(id);
            if (playMode == null)
            {
                return HttpNotFound();
            }
            return View(playMode);
        }

        // POST: PlayModes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayMode playMode = db.playModes.Find(id);
            db.playModes.Remove(playMode);
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
