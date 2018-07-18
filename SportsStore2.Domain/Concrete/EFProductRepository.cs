using SportsStore2.Domain.Abstract;
using SportsStore2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore2.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }

        public void Save(Product p_Product)
        {
            if (p_Product.ProductID == 0)
            {
                context.Products.Add(p_Product);
            }
            else
            {
                Product lProduct = context.Products.FirstOrDefault(e => e.ProductID == p_Product.ProductID);

                if (lProduct != null)
                {
                    lProduct.Name = p_Product.Name;
                    lProduct.Price = p_Product.Price;
                    lProduct.Description = p_Product.Description;
                    lProduct.Category = p_Product.Category;
                    lProduct.ImageData = p_Product.ImageData;
                    lProduct.ImageMimeType = p_Product.ImageMimeType;
                }
            }

            context.SaveChanges();
        }


        public Product Delete(int p_ProductID)
        {
            Product lProduct = context.Products.FirstOrDefault(e => e.ProductID == p_ProductID);

            if (lProduct != null)
            {
                context.Products.Remove(lProduct);
            }
            context.SaveChanges();

            return lProduct;
        }
    }
}
