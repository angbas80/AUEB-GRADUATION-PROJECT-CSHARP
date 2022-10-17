using WebApplication1.Model;

namespace WebApplication1.DAO
{
    public interface IProductDao
    {
        void Insert(Product? product);
        void Update(Product? product);
        Product? Delete(Product? product);
        Product GetProduct(int id);
        List<Product> GetAll();
    }
}
