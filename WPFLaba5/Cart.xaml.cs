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
    /// Логика взаимодействия для Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        List<CartItem> items = CartItemFromDb.LoadCartItemFromDb();
       
        public Cart()
        {
            InitializeComponent();
            listView.ItemsSource = items;
            int Summ = Shop.Itogo;
            Itogo.Text = "Итого: " + Summ;
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
                listView.ItemsSource = items;
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

        private void ClearCartBtn_Click(object sender, RoutedEventArgs e)
        {
            CartItemFromDb db = new CartItemFromDb();
            db.DeleteCartItemsFromDb();
            items.Clear();
            listView.ItemsSource = items;
            Shop.Itogo = 0;
            Cart cart = new Cart();
            cart.Show();
            this.Close();
            MessageBox.Show("Ваша корзина пуста");
            
        }

        private void BuyBtn_Click(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            foreach (var item in items)
            {
                orders.listView.Items.Add(item);
            }
            this.Close();
            orders.Show();
        }
    }
}
