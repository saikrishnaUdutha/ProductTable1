using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductTable1.Models;
using PagedList;



namespace ProductTable1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index2( int? page)
        {
            using (ProductdbModel db = new ProductdbModel())
            {
                var pagenumber = page ?? 1;
                var pagesize = 10;
                return View(db.CategoryTables.OrderBy(x => x.CategoryId).ToPagedList(pagenumber,pagesize));
            }
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            using (ProductdbModel db = new ProductdbModel())
            {
                return View(db.CategoryTables.Where(x  => x.CategoryId == id).First());
            }
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();

        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryTable leg)
        {
            try
            {
                // TODO: Add insert logic here
                using (ProductdbModel db = new ProductdbModel())
                {
                    db.CategoryTables.Add(leg);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            using (ProductdbModel db = new ProductdbModel())
            {
                return View(db.CategoryTables.Where(x => x.CategoryId == id).FirstOrDefault());
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryTable cat)
        {
            try
            {
                // TODO: Add update logic
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

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            using (ProductdbModel db = new ProductdbModel())
            {
                return View(db.CategoryTables.Where(x => x.CategoryId == id).FirstOrDefault());
            }
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoryTable leg)
        {
            try
            {
                // TODO: Add delete logic here
                using (ProductdbModel db = new ProductdbModel())
                {
                    leg = db.CategoryTables.Where(x => x.CategoryId == id).FirstOrDefault();
                    db.CategoryTables.Remove(leg);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
   
        public ActionResult Index1(int ? page)
        {
            using (ProductdbModel db = new ProductdbModel())
            {
                var pagenumber = page ?? 1;
                var pagesize = 10;
                var veb = db.Product().AsEnumerable().ToList();
                 var turk =veb.ToPagedList(pagenumber, pagesize);
                return View(turk);
            }
        }

        
    }
}
