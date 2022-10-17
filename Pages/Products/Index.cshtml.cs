using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.DAO;
using WebApplication1.Model;
using WebApplication1.Service;

namespace WebApplication1.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductDao _productDao = new ProductDaoImpl();
        private readonly IProductService? _service;

        public List<Product> Products = new();

        public IndexModel()
        {
            _service = new ProductServiceImpl(_productDao);
        }

        public void OnGet()
        {
            try
            {
                Products = _service!.GetAllProducts()!;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
