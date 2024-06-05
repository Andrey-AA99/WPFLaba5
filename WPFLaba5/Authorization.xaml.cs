using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Npgsql;
using WPFLaba5.AppData;

namespace WPFLaba5
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        
        UserFromDb userFromDb = new UserFromDb();

        public static User currentUser {  get; set; }

        public Authorization()
        {
            InitializeComponent();

            DataContext = this;
            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }
            }
        }


        private void Login(object sender, RoutedEventArgs e)
        {
            if(pass == null && email == null)
            {
                MessageBox.Show("Введите данные");
                return;
            }
            else
            {
                
                currentUser = userFromDb.GetUser(email.Text, pass.Password);
                if(currentUser!=null)
                {
                    if (pass.Password == currentUser.Password)
                    {
                    Shop shop = new Shop();
                    shop.Show();
                    this.Close();
                    }else {
                    MessageBox.Show("НЕВЕРНЫЙ ПАРОЛЬ"); 
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                    
             
                
            }
            

        }

        private void GoToRegistration(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }
    }
}
