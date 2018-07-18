using SportsStore2.Domain.Abstract;
using SportsStore2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore2.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IProductRepository repository;

        public AdminController(IProductRepository repository)
        {
            this.repository = repository;
        }
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View(repository.Products);
        }

        public ActionResult Edit(int p_ProductID)
        {
            Product lProduct;
            if (p_ProductID == 0)
            {
                lProduct = new Product();
            }
            else
            {
                lProduct = repository.Products.FirstOrDefault(e => e.ProductID == p_ProductID);
            }

            return View(lProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product p_Product)
        {
            if (ModelState.IsValid)
            {
                repository.Save(p_Product);
                TempData["Message"] = string.Format("{0} has been saved", p_Product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(p_Product);
            }
        }

        public ActionResult Delete(int p_ProductID)
        {
            Product lProduct = repository.Delete(p_ProductID);
            TempData["message"] = string.Format("{0} has been deleted!", lProduct.Name);
            return RedirectToAction("Index");
        }
    }
}