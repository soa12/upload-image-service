using laba2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;
using System.Web.Hosting;
using System.Text.RegularExpressions;

namespace laba2.Controllers
{
    public class ImageController : Controller
    {
        ImageContext db = new ImageContext();
        // GET: Image
        public ActionResult Index(int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(db.Images.ToList().ToPagedList(pageNumber, pageSize));
        }

        public FileContentResult GetImage(byte[] data)
        {
            if (data != null)
            {
                var file = File(data, "jpg");
                return file;
            }
            else
            {
                return null;
            }
        }

        // GET: Image/Details/5
        public ActionResult Details(Guid id)
        {

            return PartialView(db.Images.Find(id));
        }

        // GET: Image/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Image image, HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                // путь к папке Files
                var id = Guid.NewGuid();
        
                Regex regex = new Regex(@"/(.*)");
                Match match = regex.Match(uploadImage.ContentType);
                string path = "/Content/Images/" + id.ToString() + "." + match.Groups[1].ToString();
                uploadImage.SaveAs(Server.MapPath(path));
                image.Id = id;
                image.PathToPhoto = path;
                db.Images.Add(image);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

            //try
            //{
            //if (ModelState.IsValid && uploadImage != null)
            //{
            //    byte[] imageData = null;
            //    // считываем переданный файл в массив байтов
            //    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
            //    {
            //        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
            //        binaryReader.BaseStream.Write(imageData, 0, imageData.Length);
            //    }
            //    // установка массива байтов
            //    image.Data = imageData;
            //    image.Id = Guid.NewGuid();
            //    db.Images.Add(image);
            //    db.SaveChanges();

            //    return RedirectToAction("Index");
            //}
            //return View(image);
            //}
            //catch(Exception ex)
            //{

            //    return View("<h2>" + ex.Message + "</h2>");
            //}
        }

        //[HttpPost]
        public RedirectToRouteResult ToLike(Guid id)
        {
            Image image = db.Images.Find(id);
            image.Likes++;
            db.Entry(image).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public RedirectToRouteResult ToDislike(Guid id)
        {
            Image image = db.Images.Find(id);
            image.Dislikes++;
            db.Entry(image).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Image/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Image/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Image/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Image/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
