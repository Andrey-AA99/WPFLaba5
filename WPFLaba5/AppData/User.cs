using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLaba5.AppData
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public DateTime DateBirth { get; set; }

        public string City {  get; set; }

        public string Addres {  get; set; }

        public string Phone {  get; set; }

        public string Email { get; set; }

        public int Sale { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }

        public User(int userId, string userName, DateTime dateBirth, string city, string addres, string phone, string email, string password, int role, int sale)
        {
            UserId = userId;
            UserName = userName;
            DateBirth = dateBirth;
            City = city;
            Addres = addres;
            Phone = phone;
            Email = email;
            Sale = sale;
            Password = password;
            Role = role;
        }
    }
}
