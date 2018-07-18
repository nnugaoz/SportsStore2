using SportsStore2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore2.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart Cart = null;

            if (controllerContext.HttpContext.Session != null)
            {
                Cart = (Cart)controllerContext.HttpContext.Session["Cart"];
            }

            if(Cart==null)
            {
                Cart = new Cart();

                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session["Cart"] = Cart;
                }
            }

            return Cart;
        }
    }
}