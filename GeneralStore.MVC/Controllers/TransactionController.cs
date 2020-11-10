using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}