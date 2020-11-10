using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace GeneralStore.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            return View(_db.Transactions.ToList());
        }
        //GET: Transaction/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(_db.Products.ToList(), "ProductId", "Name");
            ViewBag.CustomerId = new SelectList(_db.Customers.ToList(), "CustomerId", "FullName");
            return View();
        }
        //POST: Transaction/Create
        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }
        //GET: Transaction/Edit/{id}
        public ActionResult Edit(int? id)
        {
            ViewBag.ProductId = new SelectList(_db.Products.ToList(), "ProductId", "Name");
            ViewBag.CustomerId = new SelectList(_db.Customers.ToList(), "CustomerId", "FullName");

            if (id is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction is null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }
        //POST: Transaction/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(transaction).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }
        //GET: Transaction/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction is null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }
        //POST: Transaction/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Transaction transaction = _db.Transactions.Find(id);
            _db.Transactions.Remove(transaction);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Transaction/Details/{id}
    }
}