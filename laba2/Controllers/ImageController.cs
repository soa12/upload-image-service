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

namespace laba2.Controllers
{
    public class ImageController : Controller
    {
        ImageContext db = new ImageContext();
        // GET: Image
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(db.Images.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Image/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            //try
            //{
                if (ModelState.IsValid && uploadImage != null)
                {
                    byte[] imageData = null;
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    // установка массива байтов
                    image.Data = imageData;
                    image.Id = Guid.NewGuid();
                    db.Images.Add(image);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(image);
            //}
            //catch(Exception ex)
            //{

            //    return View("<h2>" + ex.Message + "</h2>");
            //}
        }

        [HttpPost]
        public void ToLike(int id)
        {
            Image image = db.Images.Find(id);
            image.Likes++;
            db.Entry(image).State = EntityState.Modified;
            db.SaveChanges();
        }

        [HttpPost]
        public void ToDislike(int id)
        {
            Image image = db.Images.Find(id);
            image.Dislikes++;
            db.Entry(image).State = EntityState.Modified;
            db.SaveChanges();
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
