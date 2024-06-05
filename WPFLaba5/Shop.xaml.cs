using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WPFLaba5.AppData;


namespace WPFLaba5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shop : Window
    {

        List<CartItem> items = CartItemFromDb.LoadCartItemFromDb();
        public static int Itogo = 0;

        int count = 1;
        public List<Product> products {  get; set; }

        CategoryFromDb categoryFromDb = new CategoryFromDb();
        public Shop()
        {
            InitializeComponent();

            var converter = new BrushConverter();
            if (Authorization.currentUser.Role == 2)
            {
                AddProductBtn.Visibility = Visibility.Hidden; AddProductBtn.IsEnabled = false;
            }
            
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
            if(e.ClickCount == 2) {
                if(IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized= false;
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

        private void ChooseRoseBtn(object sender, RoutedEventArgs e)
        {
            categoryName.Text = categoryFromDb.GetCategory(1).Name;
            products = ProductFromDb.LoadFromDb(1);
            listView.ItemsSource = products;
        }

        private void ChooseRomashkiBtn(object sender, RoutedEventArgs e)
        {
            categoryName.Text = categoryFromDb.GetCategory(2).Name;
            products = ProductFromDb.LoadFromDb(2);
            listView.ItemsSource = products;
        }

        private void ChooseTulpaniBtn(object sender, RoutedEventArgs e)
        {
            categoryName.Text = categoryFromDb.GetCategory(3).Name;
            products = ProductFromDb.LoadFromDb(2);
            listView.ItemsSource = products;
        }

        private void ChooseGvozdikiBtn(object sender, RoutedEventArgs e)
        {
            categoryName.Text = "Гвоздики";
        }

        private void ChooseGerberiBtn(object sender, RoutedEventArgs e)
        {
            categoryName.Text = "Герберы";
        }

        private void ChooseSostavnieBtn(object sender, RoutedEventArgs e)
        {
            categoryName.Text = "Составные букеты";
        }

        private void ProfileOpenBtn(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }

        private void BuyBtn_Click(object sender, RoutedEventArgs e)
        {
            

        }

       

        private void OpenCartBtn(object sender, RoutedEventArgs e)
        {
            Cart cart = new Cart();
            cart.Show();
            this.Close();
        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Product product = (Product)((ListView)sender).SelectedItem;
            Itogo += product.Price;
            CartItemFromDb cartItemFromDb = new CartItemFromDb();
            cartItemFromDb.ItemAddToCart(product.ImageSource, product.Name,product.Price);
            CountInCart.Text = count.ToString();
            count++;
            
        }

        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }

   
}