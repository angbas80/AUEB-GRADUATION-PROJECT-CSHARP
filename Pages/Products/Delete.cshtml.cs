using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.DAO;
using WebApplication1.DTO;
using WebApplication1.Model;
using WebApplication1.Service;

namespace WebApplication1.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductDao? productDao = new ProductDaoImpl();
        private readonly IProductService? service;

        public DeleteModel()
        {
            service = new ProductServiceImpl(productDao);
        }

      
        internal ProductDto ProductDto = new ProductDto();
        public string ErrorMessage = "";

        public void OnGet()
        {
            try
            {
                Product? product;

                int id = int.Parse(Request.Query["id"]);
                ProductDto.Id = id;
                Console.WriteLine(ProductDto.Id);
                product = service!.DeleteProduct(ProductDto);
                Console.WriteLine(ProductDto.Id);
                Response.Redirect("/Products/Index");

            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }
    }
}
