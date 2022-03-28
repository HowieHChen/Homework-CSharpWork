using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    [Serializable]
    public class Order
    {
        public Order()
        {
            OrderID = -1;
            Client = "NULL";
            OrderAmount = -1;
        }
        public Order(int orderID, string client, double orderAmount, List<OrderDetails> items)
        {
            OrderID = orderID;
            Client = client;
            OrderAmount = orderAmount;
            Items = items;
        }
        public int OrderID { get; set; }
        public string Client { get; set; }
        public double OrderAmount { get; set; }
        public List<OrderDetails> Items { get; set; }

        public override string ToString()
        {
            return ("OrderID:" + OrderID + " Client:" + Client + " OrderAmount:" + OrderAmount);
        }

        public override bool Equals(object? obj)
        {
            Order order = obj as Order;
            return order != null && (OrderID == order.OrderID || (Client == order.Client && OrderAmount == order.OrderAmount));
        }

        public override int GetHashCode()
        {
            return OrderID.GetHashCode() ^ Client.GetHashCode() ^ OrderAmount.GetHashCode();
        }
    }
}
