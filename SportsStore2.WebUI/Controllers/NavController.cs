using SportsStore2.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore2.WebUI.Controllers
{
    public class NavController : Controller
    {
        IProductRepository repository;

        public NavController(IProductRepository repository)
        {
            this.repository = repository;
        }
        // GET: Nav
        public PartialViewResult Menu(string SelectedCategory)
        {
            IEnumerable<string> Categories = repository.Products
                .Select(e => e.Category)
                .Distinct()
                .OrderBy(e => e);
            ViewBag.SelectedCategory = SelectedCategory;
            return PartialView(Categories);
        }
    }
}