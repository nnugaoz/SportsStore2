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
        IOrderProcessor orderProcessor;

        public CartController(IProductRepository repository,IOrderProcessor orderProcessor)
        {
            this.repository = repository;
            this.orderProcessor = orderProcessor;
        }

        public RedirectToRouteResult AddToCart(Cart Cart, int ProductID, string ReturnUrl)
        {
            Product Product = repository.Products.FirstOrDefault(e => e.ProductID == ProductID);
            if (Product != null)
            {
                Cart.AddItem(Product, 1);
            }
            return RedirectToAction("Index", new { ReturnUrl = ReturnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart Cart, int ProductID, string ReturnUrl)
        {
            Cart.RemoveItem(ProductID);
            return RedirectToAction("Index", new { ReturnUrl = ReturnUrl });
        }

        public PartialViewResult Summary(Cart Cart)
        {
            return PartialView(Cart);
        }

        public ViewResult CheckOut()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult CheckOut(Cart Cart,ShippingDetails shippingDetails)
        {
            if(ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(Cart, shippingDetails);
                Cart.Clear();
                return View("Thanks");
            }
            else
            { 
                return View(shippingDetails);
            }
        }

        // GET: Cart
        public ViewResult Index(Cart Cart, string ReturnUrl)
        {
            CartIndexViewModel model = new CartIndexViewModel
            {
                Cart = Cart
                ,
                ReturnUrl = ReturnUrl
            };
            return View(model);
        }
    }
}