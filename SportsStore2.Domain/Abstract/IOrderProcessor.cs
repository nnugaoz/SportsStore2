﻿using SportsStore2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore2.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart p_Cart, ShippingDetails p_ShippingDetails);
    }
}
