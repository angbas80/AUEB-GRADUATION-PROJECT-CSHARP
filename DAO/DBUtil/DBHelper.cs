using System.Data.SqlClient;

namespace WebApplication1.DAO.DBUtil
{
    public class DbHelper
    {
        private static SqlConnection? _connection;

        ///<summary>
        ///No instances of this class should be available
        ///</summary>
        private DbHelper() { }

        public static SqlConnection? GetConnection()
        {
            try
            {
                ConfigurationManager configurationManager = new();
                configurationManager.AddJsonFile("appsettings.json");

                string url = configurationManager.GetConnectionString("DefaultConnection");
                _connection = new SqlConnection(url);
                return _connection;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return null;
        }

        public static void CloseConnection()
        {
            _connection?.Close();
        }
    }
}
