using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using WebAppWithSQL.Models;

namespace WebAppWithSQL.Services
{
    public class ProductService
    {

        private static string db_source = "appserver12330.database.windows.net";
        private static string db_user = "aleshaadmin";
        private static string db_password = "myPass123@ABC";
        private static string db_database = "appDB";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            List<Product> products = new List<Product>();
            conn.Open();

            string statement = "SELECT PRODUCTID,PRODUCTNAME,QUANTITY FROM Products";

            SqlCommand cmd = new SqlCommand(statement, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    products.Add(product);
                }

            }
            conn.Close();
            return products;
        }
    }
}
