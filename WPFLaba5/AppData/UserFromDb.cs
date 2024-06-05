using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Npgsql;


namespace WPFLaba5.AppData
{
    public class UserFromDb
    {

        private string connstring = "Host=localhost;Port=5432;User Id = postgres; Password = 0919; Database=FlowerDeliveryDB;";

        public bool CheckPassword(string password, string passRepeat)
        {
            if(password.Length < 6)
            {
                MessageBox.Show("Длина пароля не может быть меньше 6 символов");
                return false;
            }
            else
            {
                bool f, f1;
                f = f1  = false;
                for(int i =0; i < password.Length; i++)
                {
                    if (Char.IsDigit(password[i])) f1 = true;
                    if (f1) break;
                }
                if (!(f1))
                {
                    MessageBox.Show("Пароль должен содержать хотя бы одну цифру");
                    return f1;
                }
                else
                {
                    string simbol = ".!@#$%^";
                    for (int i = 0; i < password.Length; i++)
                    {
                        for (int j = 0; j < simbol.Length; j++)
                            if (password[i] == simbol[j]) { f = true; break; }
                    }
                    if (!f) MessageBox.Show("Пароль должен содержать хотя бя один символ");
                    if ((password == passRepeat) && f) return true; else { MessageBox.Show("Пароли не совпадают"); return false; }
                }
            }
        }

        //Получение пользователя по почте и паролю
        public User GetUser(string email, string password)
        {
            User user = null;
            try
            {
                using (NpgsqlConnection connect = new NpgsqlConnection(connstring))
                {
                    connect.Open();

                    string sqlExp = "Select * from client where cl_email=@email and cl_pass=@pass";
                    NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connect);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("pass", password);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (password != "")
                        {
                            DateTime birthday = DateTime.Now;
                            if (!(reader[2] is DBNull))
                            {
                                birthday = Convert.ToDateTime(reader[2]);
                            }

                            user = new User((int)reader[0], reader[1].ToString(), birthday, reader[3].ToString(), reader[4].ToString(),
                                reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), (int)reader[8], (int)reader[9]);
                        }
                        else
                        {
                            MessageBox.Show("Поля должны быть заполнены");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нет такого пользователя");
                    }
                    return user;
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return user;
            }
        }


        // Проверка пользователя на существование в БД

        public bool CheckUser(string email)
        {
            try
            {
                using(NpgsqlConnection conn = new NpgsqlConnection(connstring))
                {
                    conn.Open();

                    string sqlExp = "Select cl_email from client where cl_email=@email";
                    NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Такой пользователь уже существует");
                        return false;
                    }
                    else
                    {
                        reader.Close();
                        return true;
                    }
                }
            }catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        // Добавление пользователя в БД

        public void UserAdd(string email,string password,string fio,string city,string addres, string phone)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connstring);
            try
            {
                connection.Open();
                string sqlExp = "call insert_client_data(@fio,@city,@addres,@phone,@email,@pass)";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connection);
                cmd.Parameters.AddWithValue("fio", fio);
                cmd.Parameters.AddWithValue("city", city);
                cmd.Parameters.AddWithValue("addres", addres);
                cmd.Parameters.AddWithValue("phone", phone);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("pass", password);
                int i = cmd.ExecuteNonQuery();
                if(i == -  1){
                    MessageBox.Show("Вы успешно зарегистрированы");
                }
                else
                {
                    MessageBox.Show("Ошибка записи");
                }

            }
            catch(NpgsqlException ex) 
            {
                MessageBox.Show(ex.Message);
                return;
            }
            connection.Close();
            
        }



    }
}
