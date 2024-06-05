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
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        List<CartItem> items = CartItemFromDb.LoadCartItemFromDb();
        List<string> deliveries = DeliveryFromDb.GetDeliveryName();
        public Orders()
        {
            InitializeComponent();
            ClientAddres.Text = "Адрес доставки: " + Authorization.currentUser.City + " "+ Authorization.currentUser.Addres;
            Summ.Text = "Итого к оплате: " + Shop.Itogo;
            DeliveryBox.ItemsSource = deliveries;
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

        private void Logout(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены?", "", MessageBoxButton.OKCancel);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                CartItemFromDb db = new CartItemFromDb();
                db.DeleteCartItemsFromDb();
                items.Clear();
                Authorization authorization = new Authorization();
                authorization.Show();
                this.Close();
            }
            else
            {

            }
        }
        private void ProfileOpenBtn(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }
        private void ShopOpenBtn(object sender, RoutedEventArgs e)
        {
            Shop shop = new Shop();
            shop.Show();
            this.Close();
        }
    }
}
