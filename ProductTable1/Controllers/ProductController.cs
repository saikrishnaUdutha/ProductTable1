using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductTable1.Models;

namespace ProductTable1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index3()
        {
            using (ProductdbModel db = new ProductdbModel())
            {
                return View(db.ProductTables.ToList());
            }
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            using (ProductdbModel db = new ProductdbModel())
            {
                return View(db.ProductTables.Where(x => x.ProductId == id).FirstOrDefault());
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductTable leg)
        {
            try
            {
                // TODO: Add insert logic here
                using (ProductdbModel db = new ProductdbModel())
                {
                    db.ProductTables.Add(leg);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            using (ProductdbModel db = new ProductdbModel())
            {
                return View(db.ProductTables.Where(x => x.ProductId == id).FirstOrDefault());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductTable cat)
        {
            try
            {
                // TODO: Add update logic here
                using (ProductdbModel db = new ProductdbModel())
                {
                    db.Entry(cat).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (ProductdbModel db = new ProductdbModel())
            {
                return View(db.ProductTables.Where(x => x.ProductId == id).FirstOrDefault());
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProductTable leg)
        {
            try
            {
                // TODO: Add delete logic here
                using (ProductdbModel db = new ProductdbModel())
                {
                    leg = db.ProductTables.Where(x => x.ProductId == id).FirstOrDefault();
                    db.ProductTables.Remove(leg);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
