using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFLaba5.AppData
{
    public class ProductFromDb
    {
        private static string connstring = "Host=localhost;Port=5432;User Id = postgres; Password = 0919; Database=FlowerDeliveryDB;";

        public static List<Product> LoadFromDb(int id)
        {

            List<Product> products = new List<Product>();
            try
            {
                using (NpgsqlConnection connect = new NpgsqlConnection(connstring))
                {
                    connect.Open();
                    string sqlExp = "Select* from products where category_id=@category_id";
                    NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connect);
                    cmd.Parameters.AddWithValue("category_id", id);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        products.Add(new Product(
                            (int)reader[0],
                            reader[1].ToString(),
                            (int)reader[2],
                            (int)reader[3],
                            (int)reader[4],
                            (int)reader[5],
                            reader[6].ToString()
                            ));
                        
                    }

                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return products;
        }

        public static List<Product> LoadFromDb()
        {

            List<Product> products = new List<Product>();
            try
            {
                using (NpgsqlConnection connect = new NpgsqlConnection(connstring))
                {
                    connect.Open();
                    string sqlExp = "Select* from products";
                    NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connect);
                    
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        products.Add(new Product(
                            (int)reader[0],
                            reader[1].ToString(),
                            (int)reader[2],
                            (int)reader[3],
                            (int)reader[4],
                            (int)reader[5],
                            reader[6].ToString()
                            ));

                    }

                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return products;
        }

        public static void AddProduct(string productname,int categoryid,int productprice,int providerid,int productfactcount, string productimage)
        {
            try
            {
                using (NpgsqlConnection connect = new NpgsqlConnection(connstring))
                {
                    connect.Open();
                    string sqlExp = "INSERT INTO products (product_id,product_name,category_id,product_price,provider_id,product_fact_count,product_image)" +
                        "values (@productname,@categoryid,@productprice,@providerid,@productfactcount,@productimage)";
                    NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connect);
                    cmd.Parameters.AddWithValue("productname", productname);
                    cmd.Parameters.AddWithValue("categoryid", categoryid);
                    cmd.Parameters.AddWithValue("productprice", productprice);
                    cmd.Parameters.AddWithValue("providerid", providerid);
                    cmd.Parameters.AddWithValue("productfactcount", productfactcount);
                    cmd.Parameters.AddWithValue("productimage", productimage);




                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
