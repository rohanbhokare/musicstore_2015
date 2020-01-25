using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MusicStore.Models;


namespace MusicStore.Controllers
{
    [Authorize]
    public class StoreManagerController : Controller
    {
        //
        // GET: /StoreManager/
        MusicStoreDbEntities1 db = new MusicStoreDbEntities1();
        public ActionResult Index()
        {
         
            List<Album> obj = db.Albums.ToList();
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Album obj)
        {
            db.Albums.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Album obj = db.Albums.SingleOrDefault(x => x.AlbumId == id);
            return View(obj);
        }

        public ActionResult Delete(int id)
        {
            Album obj = db.Albums.SingleOrDefault(x => x.AlbumId == id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            int n = int.Parse(id);
            Album obj = db.Albums.SingleOrDefault(x => x.AlbumId == n);
            db.Albums.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Album obj = db.Albums.SingleOrDefault(x => x.AlbumId == id);

            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(Album obj)
        {
            Album Eobj = db.Albums.SingleOrDefault(x => x.AlbumId == obj.AlbumId);
            Eobj.ArtistName = obj.ArtistName;
            Eobj.CategoryName = obj.CategoryName;
            Eobj.Title = obj.Title;
            Eobj.UintPrice = obj.UintPrice;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
