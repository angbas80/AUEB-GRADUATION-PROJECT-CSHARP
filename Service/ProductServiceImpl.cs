using WebApplication1.DAO;
using WebApplication1.DTO;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class ProductServiceImpl : IProductService
    {
        private readonly IProductDao _dAo;

        //Dependency Injection
        public ProductServiceImpl(IProductDao dAo)
        {
            this._dAo = dAo;
        }

        private Product Convert(ProductDto? dTo)
        {
            return new Product()
            {
                Id = dTo!.Id,
                Name = dTo.Name,
                Description = dTo.Description
            };
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                return _dAo.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public Product GetProduct(int id)
        {
            try
            {
                return _dAo.GetProduct(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertProduct(ProductDto dTo)
        {
            Product product = Convert(dTo);

            try
            {
                _dAo.Insert(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void UpdateProduct(ProductDto dTo)
        {
            Product product = Convert(dTo);

            try
            {
                Console.WriteLine("Product in service" + product);
                _dAo.Update(product);
            }
            catch (Exception e) 
            { 
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public Product? DeleteProduct(ProductDto dTo)
        {
            Product product = Convert(dTo);

            try
            {
                Console.WriteLine(product.Id);
                return _dAo.Delete(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
