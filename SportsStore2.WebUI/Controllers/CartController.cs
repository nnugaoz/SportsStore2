using SportsStore2.Domain.Abstract;
using SportsStore2.Domain.Entities;
using SportsStore2.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore2.WebUI.Controllers
{
    public class CartController : Controller
    {
        IProductRepository repository;

        public CartController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public RedirectToRouteResult AddToCart(int ProductID, string ReturnUrl)
        {
            Product Product = repository.Products.FirstOrDefault(e=>e.ProductID==ProductID);
            if(Product!=null)
            {
                GetCart().AddItem(Product, 1);
            }
            return RedirectToAction("Index", new { ReturnUrl=ReturnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(int ProductID, string ReturnUrl)
        {
            GetCart().RemoveItem(ProductID);
            return RedirectToAction("Index", new { ReturnUrl = ReturnUrl });
        }

        private Cart GetCart()
        {
            Cart Cart = (Cart)Session["Cart"];

            if (Cart == null)
            {
                Cart = new Cart();
                Session["Cart"] = Cart;
            }
            return Cart;
        }



        // GET: Cart
        public ViewResult Index(string ReturnUrl)
        {
            CartIndexViewModel model = new CartIndexViewModel
            {
                Cart = GetCart()
                ,
                ReturnUrl = ReturnUrl
            };
            return View(model);
        }
    }
}