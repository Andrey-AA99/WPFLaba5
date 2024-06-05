using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFLaba5.AppData
{
    public class CartItemFromDb
    {
        private static string connstring = "Host=localhost;Port=5432;User Id = postgres; Password = 0919; Database=FlowerDeliveryDB;";
        
        public void ItemAddToCart( string image,string title, int price)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connstring);
            try
            {
                connection.Open();
                string sqlExp = "insert into cart (item_image,item_title,item_price) values (@image,@title,@price)";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connection);
                cmd.Parameters.AddWithValue("@image",image);
                cmd.Parameters.AddWithValue("@title",title);
                cmd.Parameters.AddWithValue("@price",price);

                int i = cmd.ExecuteNonQuery();
                if (i == -1)
                {
                    MessageBox.Show("Вы успешно добавили товар в корзину");
                }
                else
                {
                    MessageBox.Show("Вы успешно добавили товар в корзину");
                }



            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            connection.Close();

        }

        public static List<CartItem> LoadCartItemFromDb()
        {

            List<CartItem> cartItems = new List<CartItem>();
            try
            {
                using (NpgsqlConnection connect = new NpgsqlConnection(connstring))
                {
                    connect.Open();
                    string sqlExp = "Select* from cart";
                    NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connect);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cartItems.Add(new CartItem(
                            reader[0].ToString(),
                            reader[1].ToString(),
                            (int)reader[2]
                            ));

                    }

                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return cartItems;
        }

        public void DeleteCartItemsFromDb()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connstring);
            try
            {
                connection.Open();
                string sqlExp = "delete from cart";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connection);
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message );
            }

            }


    }
}
