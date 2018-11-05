using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using aw_db_editor;

namespace aw_db_editor.Controllers
{
    /// <summary>
    /// Products controller
    /// </summary>
    [RoutePrefix("api")]
    public class ProductsController : Controller
    {
        private AdventureWorksEntities db = new AdventureWorksEntities();

        // GET: Products
        [HttpGet]
        [Route("index")]
        public ActionResult Index()
        {
            Logger.Current.Error("Log error test!!!");

            var product = db.Product.Include(p => p.ProductModel).Include(p => p.ProductSubcategory).Include(p => p.UnitMeasure).Include(p => p.UnitMeasure1).Include(p => p.ProductDocument);
            return View(product.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductModelID = new SelectList(db.ProductModel, "ProductModelID", "Name");
            ViewBag.ProductSubcategoryID = new SelectList(db.ProductSubcategory, "ProductSubcategoryID", "Name");
            ViewBag.SizeUnitMeasureCode = new SelectList(db.UnitMeasure, "UnitMeasureCode", "Name");
            ViewBag.WeightUnitMeasureCode = new SelectList(db.UnitMeasure, "UnitMeasureCode", "Name");
            ViewBag.ProductID = new SelectList(db.ProductDocument, "ProductID", "ProductID");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates new product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,ProductNumber,MakeFlag,FinishedGoodsFlag,Color,SafetyStockLevel,ReorderPoint,StandardCost,ListPrice,Size,SizeUnitMeasureCode,WeightUnitMeasureCode,Weight,DaysToManufacture,ProductLine,Class,Style,ProductSubcategoryID,ProductModelID,SellStartDate,SellEndDate,DiscontinuedDate,rowguid,ModifiedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductModelID = new SelectList(db.ProductModel, "ProductModelID", "Name", product.ProductModelID);
            ViewBag.ProductSubcategoryID = new SelectList(db.ProductSubcategory, "ProductSubcategoryID", "Name", product.ProductSubcategoryID);
            ViewBag.SizeUnitMeasureCode = new SelectList(db.UnitMeasure, "UnitMeasureCode", "Name", product.SizeUnitMeasureCode);
            ViewBag.WeightUnitMeasureCode = new SelectList(db.UnitMeasure, "UnitMeasureCode", "Name", product.WeightUnitMeasureCode);
            ViewBag.ProductID = new SelectList(db.ProductDocument, "ProductID", "ProductID", product.ProductID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductModelID = new SelectList(db.ProductModel, "ProductModelID", "Name", product.ProductModelID);
            ViewBag.ProductSubcategoryID = new SelectList(db.ProductSubcategory, "ProductSubcategoryID", "Name", product.ProductSubcategoryID);
            ViewBag.SizeUnitMeasureCode = new SelectList(db.UnitMeasure, "UnitMeasureCode", "Name", product.SizeUnitMeasureCode);
            ViewBag.WeightUnitMeasureCode = new SelectList(db.UnitMeasure, "UnitMeasureCode", "Name", product.WeightUnitMeasureCode);
            ViewBag.ProductID = new SelectList(db.ProductDocument, "ProductID", "ProductID", product.ProductID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,ProductNumber,MakeFlag,FinishedGoodsFlag,Color,SafetyStockLevel,ReorderPoint,StandardCost,ListPrice,Size,SizeUnitMeasureCode,WeightUnitMeasureCode,Weight,DaysToManufacture,ProductLine,Class,Style,ProductSubcategoryID,ProductModelID,SellStartDate,SellEndDate,DiscontinuedDate,rowguid,ModifiedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductModelID = new SelectList(db.ProductModel, "ProductModelID", "Name", product.ProductModelID);
            ViewBag.ProductSubcategoryID = new SelectList(db.ProductSubcategory, "ProductSubcategoryID", "Name", product.ProductSubcategoryID);
            ViewBag.SizeUnitMeasureCode = new SelectList(db.UnitMeasure, "UnitMeasureCode", "Name", product.SizeUnitMeasureCode);
            ViewBag.WeightUnitMeasureCode = new SelectList(db.UnitMeasure, "UnitMeasureCode", "Name", product.WeightUnitMeasureCode);
            ViewBag.ProductID = new SelectList(db.ProductDocument, "ProductID", "ProductID", product.ProductID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }


            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
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
