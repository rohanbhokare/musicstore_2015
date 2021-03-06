﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        MusicStoreDbEntities1 db = new MusicStoreDbEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["CartId"] == null)
            {
                return RedirectToAction("EmptyCart");
            }
            var q1 = from c1 in db.Carts.ToList() where c1.CartID == Session["CartId"].ToString() select c1;
            return View(q1);
        }
        [HttpPost]
        public ActionResult Index(int id, int qty)
        {
            Cart obj = new Cart();
            obj.CartID = GetCartId();
            obj.AlbumId = id;
            obj.Quantity = qty;
            obj.DateCreated = DateTime.Now;

            db.Carts.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [NonAction]
        public string GetCartId()
        {
            if (Session["CartId"] == null)
            {
                Session["CartId"] = Guid.NewGuid().ToString();
            }
            string str = Session["CartId"].ToString();
            return str;
        }

        public ActionResult Delete(int id)
        {
            Cart obj = db.Carts.SingleOrDefault(x => x.RecordId == id);
            db.Carts.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmptyCart()
        {
            return View();
        }

        public ActionResult Confirm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Confirm(Order obj)
        {
            //step 1
            obj.OrderDate = DateTime.Now;
            obj.Total = (int)Session["Total"];
            db.Orders.Add(obj);
            db.SaveChanges();
            TempData["OrderId"] = obj.OrderId;

            //step 2
            var q1 = from c1 in db.Carts.ToList() where c1.CartID == Session["CartId"].ToString() select c1;
            foreach (Cart c in q1)
            {
                OrderDetail d1 = new OrderDetail();
                d1.OrderId = obj.OrderId;
                d1.AlbumId = c.AlbumId;
                d1.Quantity = c.Quantity;
                d1.UnitPrice = c.Album.UintPrice;
                db.OrderDetails.Add(d1);
                db.SaveChanges();
            }

            foreach (Cart c in q1)
            {
                db.Carts.Remove(c);
                db.SaveChanges();
            }

            return RedirectToAction("Complete");

        }

        public ActionResult Complete()
        {
            return View();
        }
    }
}
