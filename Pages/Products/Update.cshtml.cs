using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.DAO;
using WebApplication1.DTO;
using WebApplication1.Model;
using WebApplication1.Service;
using WebApplication1.Validator;

namespace WebApplication1.Pages.Products
{
    public class UpdateModel : PageModel
    {
        private readonly IProductDao _productDao = new ProductDaoImpl();
        private readonly IProductService? _service;

        public UpdateModel()
        {
            _service = new ProductServiceImpl(_productDao);
        }

        internal ProductDto ProductDto = new ProductDto();
        public string ErrorMessage = "";
        
        public void OnGet()
        {
            try
            {
                Product? product;
               
                int id = int.Parse(Request.Query["id"]);
                product = _service!.GetProduct(id);
                ProductDto = ConvertToDto(product!);            
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }

        public void OnPost()
        {
            ErrorMessage = "";
            
            // Get DTO
            ProductDto.Id = int.Parse(Request.Form["productId"]);
            ProductDto.Name = Request.Form["productName"];
            ProductDto.Description = Request.Form["productDescription"];

            // Validate DTO
            ErrorMessage = ProductValidator.Validate(ProductDto);

            // If Error return
            if (!ErrorMessage.Equals("")) return;

            // Update student  
            try
            {
                _service!.UpdateProduct(ProductDto);
                Response.Redirect("/Products/Index");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }

        private ProductDto ConvertToDto(Product product) 
        {
            ProductDto dto = new ProductDto(); 
            dto.Id = product.Id;
            dto.Name = product.Name;
            dto.Description = product.Description;

            return dto;
        }
    }
}
