using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFLaba5.AppData
{
    public class CategoryFromDb
    {
        private string connstring = "Host=localhost;Port=5432;User Id = postgres; Password = 0919; Database=FlowerDeliveryDB;";

        public Category GetCategory(int id)
        {
            Category category = null;
            try
            {
                using (NpgsqlConnection connect = new NpgsqlConnection(connstring))
                {
                    connect.Open();

                    string sqlExp = "Select * from categories where category_id = @id";
                    NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connect);
                    cmd.Parameters.AddWithValue("id", id);

                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        category = new Category((int)reader[0], reader[1].ToString(), reader[2].ToString());
                        return category;
                    }
                    {
                        MessageBox.Show("Нет такой категории");
                        return category;
                    }
                    
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return category;
            }
        }
    }
}
