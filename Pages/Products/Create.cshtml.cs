using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.DAO;
using WebApplication1.DTO;
using WebApplication1.Service;
using WebApplication1.Validator;

namespace WebApplication1.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductDao _productDao = new ProductDaoImpl();
        private readonly IProductService? _service;

        public CreateModel()
        {
            _service = new ProductServiceImpl(_productDao);
        }

        internal ProductDto ProductDto = new();
        public string ErrorMessage = "";
        public string SuccessMessage = "";

        public void OnGet(){}

        public void OnPost()
        {
            ErrorMessage = "";
            SuccessMessage = "";

            // Get DTO
            ProductDto.Name = Request.Form["productName"];
            ProductDto.Description = Request.Form["productDescription"];

            // Validate DTO
            ErrorMessage = ProductValidator.Validate(ProductDto);

            // If there is an error return
            if (!ErrorMessage.Equals("")) return;

            // Insert Product
            try
            {
                _service?.InsertProduct(ProductDto);
                SuccessMessage = "New Product Inserted Successfully";
                // If insert is successfull, reset fields for new insert.
                ResetFields();
                // On success
                Response.Redirect("/Products/Index");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }

        private void ResetFields()
        {
            ProductDto.Name = "";
            ProductDto.Description= "";
        }
    }
}
