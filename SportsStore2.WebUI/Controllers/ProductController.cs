using SportsStore2.Domain.Abstract;
using SportsStore2.WebUI.Models;
using System.Web.Mvc;
using System.Linq;

namespace SportsStore2.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository repository;
        int PageSize = 4;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult List(string SelectedCategory,int PageIndex = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products
                .Where(e=>SelectedCategory==null||SelectedCategory==e.Category)
                .OrderBy(e => e.ProductID)
                .Skip((PageIndex - 1) * PageSize)
                .Take(PageSize)
                 ,
                PagingInfo = new PagingInfo
                {
                    TotalItems = repository.Products
                    .Where(e => SelectedCategory == null || SelectedCategory == e.Category)
                    .Count()
                    ,
                    ItemsPerPage = PageSize
                    ,
                    CurrentPage = PageIndex
                }
                ,
                SelectedCategory=SelectedCategory
            };
            return View(model);
        }
    }
}