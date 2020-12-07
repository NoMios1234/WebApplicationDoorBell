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
    public class AudioLibsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AudioLibs
        public ActionResult Index()
        {
            var audioLibs = db.audioLibs.Include(a => a.PlayMode);
            return View(audioLibs.ToList());
        }

        // GET: AudioLibs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioLib audioLib = db.audioLibs.Find(id);
            if (audioLib == null)
            {
                return HttpNotFound();
            }
            return View(audioLib);
        }

        // GET: AudioLibs/Create
        public ActionResult Create()
        {
            ViewBag.PlayModeId = new SelectList(db.playModes, "Id", "Name");
            return View();
        }

        // POST: AudioLibs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Count,Size,PlayModeId")] AudioLib audioLib)
        {
            if (ModelState.IsValid)
            {
                db.audioLibs.Add(audioLib);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayModeId = new SelectList(db.playModes, "Id", "Name", audioLib.PlayModeId);
            return View(audioLib);
        }

        // GET: AudioLibs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioLib audioLib = db.audioLibs.Find(id);
            if (audioLib == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayModeId = new SelectList(db.playModes, "Id", "Name", audioLib.PlayModeId);
            return View(audioLib);
        }

        // POST: AudioLibs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Count,Size,PlayModeId")] AudioLib audioLib)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audioLib).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayModeId = new SelectList(db.playModes, "Id", "Name", audioLib.PlayModeId);
            return View(audioLib);
        }

        // GET: AudioLibs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioLib audioLib = db.audioLibs.Find(id);
            if (audioLib == null)
            {
                return HttpNotFound();
            }
            return View(audioLib);
        }

        // POST: AudioLibs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AudioLib audioLib = db.audioLibs.Find(id);
            db.audioLibs.Remove(audioLib);
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
