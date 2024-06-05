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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {



        List<string> deliveries = DeliveryFromDb.GetDeliveryName();
       
        public Profile()
        {
            InitializeComponent();

            NameProfileText.Text = Authorization.currentUser.UserName;
            CityProfileText.Text ="Город : " +  Authorization.currentUser.City;
            DateOfBirthday.Text = "Дата рождения : "+Authorization.currentUser.DateBirth.ToShortDateString();
            PhoneNumber.Text = "Номер телефона : "+ Authorization.currentUser.Phone;
           
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

        private void ProfileOpenBtn(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены?", "", MessageBoxButton.OKCancel);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                Authorization authorization = new Authorization();
                authorization.Show();
                this.Close();
            }
            else
            {

            }

        }

        private void ShopOpenBtn(object sender, RoutedEventArgs e)
        {
            Shop shop = new Shop();
            shop.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cart cart = new Cart();
            cart.Show();
            this.Close();
        }

        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            orders.Show();
            this.Close();
        }
    }
}
