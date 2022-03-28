namespace Homework4
{
    class Program
    {
        public void FunctionOrder()
        {
            OrderService orderService = new OrderService();
            int i = -1;
            while (i != 0)
            {
                Console.WriteLine("\n请选择功能:\n1.添加订单\n2.删除订单\n3.修改订单\n4.查找订单\n5.导入\n6.导出\n7.打印所有订单\n0.退出\n");
                string func = Console.ReadLine();
                if(!int.TryParse(func, out i))
                {
                    Console.WriteLine("请重试");
                    continue;
                }
                switch (i)
                {
                    case 1: OrderAdd(orderService); break;
                    case 2: OrderDel(orderService); break;
                    case 3: OrderEdit(orderService); break;
                    case 4: OrderFind(orderService); break;
                    case 5: OrderImport(orderService); break;
                    case 6: OrderOutput(orderService); break;
                    case 7: orderService.PrintAll(); break;
                    case 0: return;
                    default: continue;
                }
            }
        }
        public void OrderAdd(OrderService orderService)
        {
            Console.WriteLine("请输入订单号");
            if(!int.TryParse(Console.ReadLine(), out int orderID))
                Console.WriteLine("输入有误");
            Console.WriteLine("请输入客户名");
            string client = Console.ReadLine();
            Console.WriteLine("请输入总金额");
            if (!double.TryParse(Console.ReadLine(), out double orderAmount))
                Console.WriteLine("输入有误");
            Console.WriteLine("请输入交易产品总类数");
            if (!int.TryParse(Console.ReadLine(), out int itemNum))
                Console.WriteLine("输入有误");
            List<OrderDetails> items = new List<OrderDetails>();
            for(int i = 0; i < itemNum; i++)
            {
                Console.WriteLine("正在录入第" + (i + 1) + "类产品");
                Console.WriteLine("请输入产品号");
                if (!int.TryParse(Console.ReadLine(), out int productID))
                    Console.WriteLine("输入有误");
                Console.WriteLine("请输入产品名");
                string productName = Console.ReadLine();
                Console.WriteLine("请输入交易量");
                if (!int.TryParse(Console.ReadLine(), out int ProductQTY))
                    Console.WriteLine("输入有误");
                Console.WriteLine("请输入产品单价");
                if (!double.TryParse(Console.ReadLine(), out double productPrice))
                    Console.WriteLine("输入有误");
                OrderDetails orderDetails = new OrderDetails(productID, productName, ProductQTY, productPrice);
                foreach (OrderDetails item in items)
                {
                    if (orderDetails.Equals(item))
                    {
                        Console.WriteLine("产品重复");
                        return;
                    }
                }
                items.Add(orderDetails);
            }
            Order order = new Order(orderID, client, orderAmount, items);
            try
            {
                orderService.Add(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public void OrderDel(OrderService orderService)
        {
            Console.WriteLine("请输入要删除的订单的订单号");
            int.TryParse(Console.ReadLine(), out int orderID);
            try
            {
                orderService.Remove(orderID);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void OrderEdit(OrderService orderService)
        {
            Console.WriteLine("请输入要修改的订单的订单号");
            if (!int.TryParse(Console.ReadLine(), out int orderID))
                Console.WriteLine("输入有误");
            IEnumerable<Order> p = orderService.Get(orderID);
            if (!p.Any())
            {
                Console.WriteLine("无对应订单");
                return ;
            }
            else
            {
                Console.WriteLine("对应的订单信息:");
                foreach (Order order in p)
                {
                    Console.WriteLine(order.ToString());
                    foreach(OrderDetails details in order.Items)
                    {
                        Console.WriteLine(details.ToString());
                    }
                }
                Console.WriteLine("请输入客户名");
                string client = Console.ReadLine();
                Console.WriteLine("请输入总金额");
                if (!double.TryParse(Console.ReadLine(), out double orderAmount))
                    Console.WriteLine("输入有误");
                Console.WriteLine("请输入交易产品总类数");
                if (!int.TryParse(Console.ReadLine(), out int itemNum))
                    Console.WriteLine("输入有误");
                List<OrderDetails> items = new List<OrderDetails>();
                for (int i = 0; i < itemNum; i++)
                {
                    Console.WriteLine("正在录入第" + (i + 1) + "类产品");
                    Console.WriteLine("请输入产品号");
                    if (!int.TryParse(Console.ReadLine(), out int productID))
                        Console.WriteLine("输入有误");
                    Console.WriteLine("请输入产品名");
                    string productName = Console.ReadLine();
                    Console.WriteLine("请输入交易量");
                    if (!int.TryParse(Console.ReadLine(), out int ProductQTY))
                        Console.WriteLine("输入有误");
                    Console.WriteLine("请输入产品单价");
                    if (!double.TryParse(Console.ReadLine(), out double productPrice))
                        Console.WriteLine("输入有误");
                    OrderDetails orderDetails = new OrderDetails(productID, productName, ProductQTY, productPrice);
                    foreach (OrderDetails item in items)
                    {
                        if (orderDetails.Equals(item))
                        {
                            Console.WriteLine("产品重复");
                            return;
                        }
                    }
                    items.Add(orderDetails);
                }
                try
                {
                    orderService.Edit(orderID, client, orderAmount, items);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }           
            }
        }
        public void OrderFind(OrderService orderService)
        {
            Console.WriteLine("\n请选择查找方式:\n1.按订单号\n2.按客户名\n3.按交易额\n4.按产品名\n0.退出\n");
            string func = Console.ReadLine();
            IEnumerable<Order> p;
            if (!int.TryParse(func, out int i))
            {
                Console.WriteLine("请重试");
                return;
            }
            switch (i)
            {
                case 1:
                    {
                        Console.WriteLine("请输入订单号");
                        int.TryParse(Console.ReadLine(), out int orderID);
                        p = orderService.Get(orderID);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("请输入客户名");
                        string client = Console.ReadLine();
                        p = orderService.Get(client);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("请输入交易额");
                        double.TryParse(Console.ReadLine(),out double orderAmount);
                        p = orderService.Get(orderAmount);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("请输入产品名");
                        string productName = Console.ReadLine();
                        p = orderService.Search(productName);
                        break;
                    }
                case 0: return;
                default: return;
            }
            if(!p.Any())
            {
                Console.WriteLine("无对应订单");
            }
            else
            {
                foreach (Order order in p)
                {
                    Console.WriteLine("\n" + order.ToString());
                    foreach (OrderDetails details in order.Items)
                    {
                        Console.WriteLine(details.ToString());
                    }
                }
            }
        }

        public void OrderImport(OrderService orderService)
        {
            Console.WriteLine("正在导入订单");
            orderService.Import();
            Console.WriteLine("已导入以下订单");
            orderService.PrintAll();
        }

        public void OrderOutput(OrderService orderService)
        {
            Console.WriteLine("正在导出订单");
            orderService.Export();
            Console.WriteLine("已导出以下订单");
            orderService.PrintAll();
        }

        public void FunctionLINQ()
        {
            Random random = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(random.Next(0,1001));
            }
            Console.WriteLine("\n原始数据\n");
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            var query1 = from li in list orderby li descending select li;
            List<int> list2 = query1.ToList();
            Console.WriteLine("\n降序排序\n");
            foreach (int i in list2)
            {
                Console.WriteLine(i);
            }
            var sum = query1.Sum();
            var avg = query1.Average();
            Console.WriteLine("\n数据和 " + sum.ToString());
            Console.WriteLine("平均值 " + avg.ToString() + "\n");
        }

        static void Main()
        {
            var program = new Program();
            Console.WriteLine("\n请选择功能:\n1.订单管理\n2.LINQ\n");
            int.TryParse(Console.ReadLine(), out int op);
            switch (op)
            {
                case 1:
                    {
                        program.FunctionOrder();
                        break;
                    }
                case 2:
                    {
                        program.FunctionLINQ();
                        break;
                    }
                default: break;
            }
        }
    }
}