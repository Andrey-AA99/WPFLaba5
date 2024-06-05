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
using WPFLaba5.AppData;

namespace WPFLaba5
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {

        UserFromDb userFromDb = new UserFromDb();
        public Registration()
        {
            InitializeComponent();
            var converter = new BrushConverter();
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

        private void RegistrBtn(object sender, RoutedEventArgs e)
        {
            if (email.Text == "" || passReg.Password == "" || passConfirm.Password =="" || city.Text == "" || addres.Text == "" || phone.Text == "" || fio.Text == "")
            {
                MessageBox.Show("Необходимо заполнить все поля");
            }
            bool rez = userFromDb.CheckPassword(passReg.Password, passConfirm.Password);
            if (!rez) {
                return;
            }
            else
            {
                if (userFromDb.CheckUser(email.Text))
                {
                    userFromDb.UserAdd(email.Text, passReg.Password, fio.Text, city.Text, addres.Text, phone.Text);
                }
                else return;
            }
            
            
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }

        private void BackBtn(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }
    }
}
