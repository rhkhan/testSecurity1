using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testSecurity1.CustomFilters;
using testSecurity1.Models;

namespace testSecurity1.Controllers
{
    public class ProductController : Controller
    {
        SuperMarketEntities ctx;
        string aaa = "Manager, SalesExecutive";
        public ProductController()
        {
            ctx = new SuperMarketEntities();
        }

        // GET: Product
        public ActionResult Index()
        {
            var Products = ctx.ProductMasters.ToList();
            return View(Products);
        }

        //[Authorize(Roles="Manager")]
        //[AuthLog(Roles="Manager")] // Custom Filter
        [Authorize(Roles = CustomRoles.roleTest)]
        public ActionResult Create()
        {
            //authorizationService.RequireRoles("Admin", "Super User");
            var Product = new ProductMaster();
            return View(Product);
        }

        [HttpPost]
        public ActionResult Create(ProductMaster p)
        {
            ctx.ProductMasters.Add(p);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "SalesExecutive")]
        [AuthLog(Roles="SalesExecutive")]
        public ActionResult SaleProduct()
        {
            ViewBag.Message = "This View is designed for the Sales Executive to Sale Product.";
            return View();
        }

    }
}