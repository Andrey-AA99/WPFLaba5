using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFLaba5.AppData
{
    public class DeliveryFromDb
    {
        private static string connstring = "Host=localhost;Port=5432;User Id = postgres; Password = 0919; Database=FlowerDeliveryDB;";

        public static List<string> GetDeliveryName()
        {
            List<string> listOfDelivery = new List<string>();
            try
            {
                using (NpgsqlConnection connect = new NpgsqlConnection(connstring))
                {
                    connect.Open();
                    string sqlExp = "Select* from delivery";
                    NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connect);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        listOfDelivery.Add(
                            reader[1].ToString()
                            );
                    }
                }
                return listOfDelivery;

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listOfDelivery;
        }

        public static List<Delivery> GetDelivery()
        {
            List<Delivery> deliveries = new List<Delivery>();
            try
            {
                using (NpgsqlConnection connect = new NpgsqlConnection(connstring))
                {
                    connect.Open();
                    string sqlExp = "Select* from delivery";
                    NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connect);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        deliveries.Add( new Delivery(
                            (int)reader[0],
                            reader[1].ToString(),
                            (int)reader[2]) 
                            );
                    }
                }
                return deliveries;

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return deliveries;
        }
    }
}
