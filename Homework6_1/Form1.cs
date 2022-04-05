using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Homework6_1
{
    public partial class Form1 : Form
    {
        OrderService orderService;
        BindingList<Order> orders;
        public Form1()
        {
            InitializeComponent();
            orderService = new OrderService();
            orders = new BindingList<Order> { };
            dataGridView1.DataSource = orders;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<Order> p;
            int.TryParse(textBox1.Text, out int orderID);
            p = orderService.Get(orderID);
            if (p != null)
            {
                orders.Clear();
                p.ToList().ForEach(o => orders.Add(o));
            }
            else
            {
                MessageBox.Show("没有找到对应订单", "错误");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            orders.Clear();
            List<Order> tempOrders = orderService.PrintAll();
            foreach (Order order in tempOrders)
            {
                orders.Add(order);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            if(form2.DialogResult == DialogResult.OK)
            {
                int OrderID = form2.OrderID;
                string Client = form2.Client;
                double OrderAmount = form2.OrderAmount;
                List<OrderDetails> Items = form2.Items;
                Order order = new Order(OrderID, Client, OrderAmount, Items);
                try
                {
                    orderService.Add(order);
                    orders.Add(order);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            int orderID = orders[index].OrderID;
            orders.RemoveAt(index);
            orderService.Remove(orderID);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            orderService.orders.Clear();
            foreach (Order order in orders)
            {
                orderService.orders.Add(order);
            }
        }
    }
}
