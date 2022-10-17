using WebApplication1.DAO.DBUtil;
using WebApplication1.Model;
using System.Data.SqlClient;

namespace WebApplication1.DAO
{
    public class ProductDaoImpl : IProductDao
    {
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            try
            {
                using SqlConnection? connection = DbHelper.GetConnection();

                connection!.Open();
                string sql = "SELECT * FROM PRODUCTS";

                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product()
                    { 
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2)
                    };
                    products.Add(product);
                }
                return products;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(Product? product)
        {
            try
            {
                using SqlConnection? connection = DbHelper.GetConnection();

                connection!.Open();
                string sql = "INSERT INTO PRODUCTS " + "(PRODUCT_NAME, PRODUCT_DESCRIPTION) VALUES" + "(@name, @description)";

                using SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@name", product!.Name);
                command.Parameters.AddWithValue("@description", product.Description);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(Product? product)
        {
            try
            {
                using SqlConnection? connection = DbHelper.GetConnection();

                connection!.Open();
                string sql = "UPDATE PRODUCTS SET PRODUCT_NAME=@name, " + 
                             "PRODUCT_DESCRIPTION=@description WHERE ID=@id";

                using SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@name", product!.Name);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@id", product.Id);
                //Console.WriteLine("Product in DAO" + product);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
        public Product? Delete(Product? product)
        {
            if (product == null) return null;
            try
            {
                using SqlConnection? connection = DbHelper.GetConnection();

                connection!.Open();
                string sql = "DELETE FROM PRODUCTS " + "WHERE ID=@id";

                using SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", product!.Id);

                int rowsAffected = command.ExecuteNonQuery();
                return (rowsAffected > 0) ? product : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Product GetProduct(int id)
        {
            try
            {
                Product? product = null;
                using SqlConnection? connection = DbHelper.GetConnection();

                connection!.Open();
                string sql = "SELECT * FROM PRODUCTS WHERE ID=@id";

                using SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    product = new()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                    };
                }
                return product!;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

    }

}
