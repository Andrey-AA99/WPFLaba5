using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLaba5.AppData
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId {  get; set; }
        public string Addres { get; set; }
        public string City {  get; set; }
        public DateTime Date { get; set; }
        public DateTime DeliveryDate {  get; set; }
        public int DeliveryId {  get; set; }
        public int DeliveryPrice { get; set; }

        public Order(int orderId, int clientId, string addres, string city, DateTime date, DateTime deliveryDate, int deliveryId, int deliveryPrice)
        {
            OrderId = orderId;
            ClientId = clientId;
            Addres = addres;
            City = city;
            Date = date;
            DeliveryDate = deliveryDate;
            DeliveryId = deliveryId;
            DeliveryPrice = deliveryPrice;
        }
    }
}
