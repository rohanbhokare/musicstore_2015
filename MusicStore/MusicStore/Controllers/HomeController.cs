using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MusicStore.Models;


namespace MusicStore.Controllers
{
    
    public class HomeController : Controller
    {
        MusicStoreDbEntities1 db = new MusicStoreDbEntities1();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var q1 = from a1 in db.Albums.ToList() orderby a1.AlbumId descending select a1;
            return View(q1.Take(5));
        }
        public ActionResult Browse(string strCatagory)
        {
            ViewBag.CatagoryName = strCatagory;
            var q2 = from a1 in db.Albums.ToList() where a1.CategoryName == strCatagory select a1;
            return View(q2);
        }
        public ActionResult ShowAll()
        {
            var q1 = from a1 in db.Albums.ToList() select a1;
            return View(q1);
        }
        public ActionResult Details(int id)
        {
            Album obj = db.Albums.SingleOrDefault(a1 => a1.AlbumId == id);
            return View(obj);
        }

    }
}
