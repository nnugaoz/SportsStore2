using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore2.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product Product, int Quantity)
        {
            CartLine line = lineCollection.FirstOrDefault(e => e.Product.ProductID == Product.ProductID);

            if (line != null)
            {
                line.Quantity += 1;
            }
            else
            {
                lineCollection.Add(new CartLine { Product = Product, Quantity = 1 });
            }
        }

        public void RemoveItem(int ProductID)
        {
            lineCollection.RemoveAll(e => e.Product.ProductID == ProductID);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public decimal ComputeTotal()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        public IEnumerable<CartLine> Lines
        {
            get
            {
                return lineCollection;
            }
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
