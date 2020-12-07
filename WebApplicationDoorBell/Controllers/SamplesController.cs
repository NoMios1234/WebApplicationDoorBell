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
    public class SamplesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Samples
        public ActionResult Index()
        {
            var samples = db.samples.Include(s => s.AudioLib);
            return View(samples.ToList());
        }
        //[HttpPost]
        //public JsonResult CheckName(string name)
        //{
        //    var absolutePath = !(System.IO.File.Exists(HttpContext.Server.MapPath("~/Files/" + name)));
        //    return Json(absolutePath, JsonRequestBehavior.AllowGet);
        //}

        // GET: Samples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.samples.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            return View(sample);
        }

        // GET: Samples/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AudioLibId = new SelectList(db.audioLibs, "Id", "Name");
            return View();
        }

        // POST: Samples/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Duration,Size,AudioLibId")] Sample sample, HttpPostedFileBase upload)
        {
            if(System.IO.File.Exists(HttpContext.Server.MapPath("~/Files/" + sample.Name)))
            {
                ModelState.AddModelError("", "Такий файл уже є в аудіотеці!");
            }
            if (upload == null)
            {
                ModelState.AddModelError("", "Виберіть аудіофайл!");
            }
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(upload.FileName);
                    // сохраняем файл в папку Files в проекте
                    upload.SaveAs(Server.MapPath("~/Files/" + fileName));
                    db.samples.Add(sample);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.AudioLibId = new SelectList(db.audioLibs, "Id", "Name", sample.AudioLibId);
            return View(sample);
        }

        
        // GET: Samples/Edit/5
        public ActionResult Edit(int? id)
        {
            Sample sample = db.samples.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (sample == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.AudioLibId = new SelectList(db.audioLibs, "Id", "Name", sample.AudioLibId);
            return View(sample);
        }
       
        // POST: Samples/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Duration,Size,AudioLibId")] Sample sample, HttpPostedFileBase upload, int? id)
        {
            if (System.IO.File.Exists(HttpContext.Server.MapPath("~/Files/" + sample.Name)))
            {
                ModelState.AddModelError("", "Такий файл уже є в аудіотеці!");
            }
            if (upload == null)
            {
                ModelState.AddModelError("", "Виберіть аудіофайл!");
            }
            if (ModelState.IsValid)
            {
                Sample oldsample = db.samples.Find(id);
                db.Entry(oldsample).State = EntityState.Modified;
                // получаем имя файла
                System.IO.File.Delete(Server.MapPath("~/Files/" + oldsample.Name));
                db.samples.Remove(oldsample);
                //db.Entry(sample).State = EntityState.Modified;
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));
                db.samples.Add(sample);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AudioLibId = new SelectList(db.audioLibs, "Id", "Name", sample.AudioLibId);
            return View(sample);
        }

        // GET: Samples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.samples.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            return View(sample);
        }

        // POST: Samples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sample sample = db.samples.Find(id);
            System.IO.File.Delete(Server.MapPath("~/Files/" + sample.Name));
            db.samples.Remove(sample);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public string Media()
        {
            return Server.MapPath("~/Files/");
        }
        public ActionResult Stream(string mp3)
        {
            byte[] file = System.IO.File.ReadAllBytes(Server.MapPath("~/Files/" + mp3));
            return File(file, "audio/mpeg");
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
