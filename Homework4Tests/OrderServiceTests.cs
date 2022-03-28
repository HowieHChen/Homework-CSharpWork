using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {

        [TestMethod()]
        public void AddTest()
        {
            var orderService = new OrderService();
            int count = 10;
            List<OrderDetails> items = new List<OrderDetails>();
            for (int i = 0; i < count; i++)
            {
                orderService.Add(i, ("c" + i), i * 2000, items);
            }
            Assert.IsTrue(orderService.orders.Count == count);
        }

        [TestMethod()]
        public void AddTest1()
        {
            var orderService = new OrderService();
            Order order;
            int count = 10;
            List<OrderDetails> items = new List<OrderDetails>();
            for (int i = 0; i < count; i++)
            {
                order = new Order(i, ("c" + i), i * 2000, items);
                orderService.Add(order);
            }
            Assert.IsTrue(orderService.orders.Count == count);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            var orderService = new OrderService();
            List<OrderDetails> items = new List<OrderDetails>();
            Order order = new Order(1, ("c" + 1), 1 * 2000, items);
            orderService.Add(order);
            orderService.Remove(order);
            Assert.IsTrue(!orderService.orders.Contains(order));
        }

        [TestMethod()]
        public void RemoveTest1()
        {
            var orderService = new OrderService();
            List<OrderDetails> items = new List<OrderDetails>();
            Order order = new Order(1, ("c" + 1), 1 * 2000, items);
            orderService.Add(order);
            orderService.Remove(1);
            Assert.IsTrue(!orderService.orders.Contains(order));
        }

        [TestMethod()]
        public void EditTest()
        {
            var orderService = new OrderService();
            List<OrderDetails> items = new List<OrderDetails>();
            Order order = new Order(1, ("c" + 1), 1 * 2000, items);
            orderService.Add(order);
            orderService.Edit(order, "c2", 1 * 2000, items);
            Assert.IsTrue(orderService.orders.Find(x => x.OrderID == 1).Client == "c2");
        }

        [TestMethod()]
        public void EditTest1()
        {
            var orderService = new OrderService();
            List<OrderDetails> items = new List<OrderDetails>();
            Order order = new Order(1, ("c" + 1), 1 * 2000, items);
            orderService.Add(order);
            orderService.Edit(1, "c2", 1 * 2000, items);
            Assert.IsTrue(orderService.orders.Find(x => x.OrderID == 1).Client == "c2");
        }

        [TestMethod()]
        public void GetTest()
        {
            var orderService = new OrderService();
            List<OrderDetails> items = new List<OrderDetails>();
            Order order = new Order(1, ("c" + 1), 1 * 2000, items);
            orderService.Add(order);
            var getReturn = orderService.Get((int)1);
            Assert.IsNotNull(getReturn);
        }

        [TestMethod()]
        public void GetTest1()
        {
            var orderService = new OrderService();
            List<OrderDetails> items = new List<OrderDetails>();
            Order order = new Order(1, ("c" + 1), 1 * 2000, items);
            orderService.Add(order);
            var getReturn = orderService.Get("c1");
            Assert.IsNotNull(getReturn);
        }

        [TestMethod()]
        public void GetTest2()
        {
            var orderService = new OrderService();
            List<OrderDetails> items = new List<OrderDetails>();
            Order order = new Order(1, ("c" + 1), 1 * 2000, items);
            orderService.Add(order);
            var getReturn = orderService.Get((double)2000);
            Assert.IsNotNull(getReturn);
        }

        [TestMethod()]
        public void RemoveAllTest()
        {
            var orderService = new OrderService();
            List<OrderDetails> items = new List<OrderDetails>();
            Order order = new Order(1, ("c" + 1), 1 * 2000, items);
            orderService.Add(order);
            orderService.RemoveAll();
            Assert.AreEqual(orderService.orders.Count, 0);
        }

        [TestMethod()]
        public void ImportTest()
        {
            var orderService = new OrderService();
            List<OrderDetails> items = new List<OrderDetails>();
            Order order = new Order(1, ("c" + 1), 1 * 2000, items);
            orderService.Add(order);
            orderService.Export();
            orderService.RemoveAll();
            orderService.Import();
            Assert.AreEqual(orderService.orders.Count, 1);
        }
    }
}