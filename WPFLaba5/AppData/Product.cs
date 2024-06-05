using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLaba5.AppData
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId {  get; set; }
        public int Price { get; set; }
        public int ProviderId {  get; set; }
        public int Count { get; set; }
        public string ImageSource {  get; set; }


        public Product(int id, string name, int categoryId, int price, int providerId, int count, string image)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Price = price;
            ProviderId = providerId;
            Count = count;
            ImageSource = image; 
        }
    }
}
