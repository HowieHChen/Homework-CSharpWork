using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Homework4
{
    [Serializable]
    public class OrderService
    {
        public List<Order> orders;
        public OrderService()
        {
            orders = new List<Order>();
        }
        
        public void Add(int orderID, string client, double orderAmount, List<OrderDetails> items)
        {
            Order order = new Order(orderID, client, orderAmount, items);
            foreach (Order od in orders)
            {
                if (order.Equals(od))
                {
                    throw new Exception("订单重复");
                }
            }
            orders.Add(order);
        }

        public void Add(Order order)
        {
            foreach (Order od in orders)
            {
                if (order.Equals(od))
                {
                    throw new Exception("订单重复");
                }
            }
            orders.Add(order);
        }

        public void Remove(Order order)
        {
            bool isEXist = false;
            foreach(Order od in orders)
                isEXist = order.Equals(od) || isEXist;
            if (!isEXist)
                throw new Exception("无此订单");
            else
                orders.Remove(order);
        }
        public void Remove(int orderID)
        {
            Order order = orders.Find(x => x.OrderID == orderID);
            if (order == null)
                throw new Exception("无此订单");
            else
                orders.Remove(order);
        }

        public void Edit(Order order, string client, double orderAmount, List<OrderDetails> items)
        {
            if (orders.Contains(order))
            {
                order.Client = client;
                order.OrderAmount = orderAmount;
                order.Items = items;
            }
            else
            {
                throw new Exception("无此订单");
            }
        }

        public void Edit(int orderID, string client, double orderAmount, List<OrderDetails> items)
        {
            Order order = orders.Find(x => x.OrderID == orderID);
            if (order == null)
                throw new Exception("无此订单");
            else
            {
                order.Client = client;
                order.OrderAmount = orderAmount;
                order.Items = items;
            }
        }

        public IEnumerable<Order> Get(int orderID)
        {
            var q = from order in orders
                    where order.OrderID == orderID
                    orderby order.OrderAmount
                    select order;
            return q;
        } 
        public IEnumerable<Order> Get(string client)
        {
            var q = from order in orders
                    where order.Client == client
                    orderby order.OrderAmount
                    select order;
            return q;
        }
        public IEnumerable<Order> Get(double orderAmount)
        {
            var q = from order in orders
                    where order.OrderAmount == orderAmount
                    orderby order.OrderID
                    select order;
            return q;
        }
        public IEnumerable<Order> Search(string productName)
        {
            var q = from order in orders
                    where order.Items.Find(x => x.ProductName == productName) != null
                    orderby order.OrderAmount
                    select order;
            return q;
        }
        public IEnumerable<Order> Search(int productID)
        {
            var q = from order in orders
                    where order.Items.Find(x => x.ProductID == productID) != null
                    orderby order.OrderAmount
                    select order;
            return q;
        }

        public void RemoveAll()
        {
            orders.Clear();
        }

        public void PrintAll()
        {
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
                foreach (var item in order.Items)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        public void Export()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("orderdata.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, orders);
            }
        }

        public void Import()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("orderdata.xml", FileMode.Open))
            {
                orders = (List<Order>)xmlSerializer.Deserialize(fs);
            }
        }
    }
}
