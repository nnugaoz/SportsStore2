using SportsStore2.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore2.Domain.Concrete
{
    public class SimplestOrderProcessor:IOrderProcessor
    {
        public void ProcessOrder(Entities.Cart p_Cart, Entities.ShippingDetails p_ShippingDetails)
        {
            
        }
    }
}
