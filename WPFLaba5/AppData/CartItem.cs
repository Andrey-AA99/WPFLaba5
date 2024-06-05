using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLaba5.AppData
{
    public class CartItem
    {
       
        public string Image {  get; set; }
        public string Title { get; set; }
        public int Price { get; set; }


        public CartItem(string image, string title, int price)
        {
            Image = image;
            Title = title;
            Price = price;
        }
    }
}
