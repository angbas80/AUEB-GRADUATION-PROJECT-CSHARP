using WebApplication1.DTO;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        void InsertProduct(ProductDto dTo);
        void UpdateProduct(ProductDto dTo);
        Product? DeleteProduct(ProductDto dTo);
    }
}
