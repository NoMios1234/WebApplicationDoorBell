using Accord.Extensions.Imaging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationDoorBell.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        private void makeAvi(string imageInputfolderName, string outVideoFileName, float fps = 12.0f, string imgSearchPattern = "*.png")
        {   // reads all images in folder 
            VideoWriter w = new VideoWriter(outVideoFileName,
                new Accord.Extensions.Size(480, 640), fps, true);
            Accord.Extensions.Imaging.ImageDirectoryReader ir =
                new ImageDirectoryReader(imageInputfolderName, imgSearchPattern);
            while (ir.Position < ir.Length)
            {
                IImage i = ir.Read();
                w.Write(i);
            }
            w.Close();
        }
        [HttpPost]
        public ActionResult SaveImg(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));
            }
            return View("Index");
        }
        public FileResult GetFile()
        {
            // Путь к файлу
            string file_path = Server.MapPath("http://192.168.1.106:81/stream");
            // Тип файла - content-type
            string file_type = "image/png";
            // Имя файла - необязательно
            string file_name = "imageFile.png";
            return File(file_path, file_type, file_name);
        }

    }
}