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
    public partial class Form2 : Form
    {
        //public bool opResult;
        public int OrderID;
        public string Client;
        public double OrderAmount;
        public List<OrderDetails> Items;

        public Form2()
        {
            InitializeComponent();
            Items = new List<OrderDetails>();
            dataGridView1.DataSource = new BindingList<OrderDetails>(Items);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderID = int.Parse(textBox1.Text.Trim());
            Client = textBox2.Text.Trim();
            OrderAmount = int.Parse(textBox3.Text.Trim());
            this.DialogResult = DialogResult.OK;
        }
    }
}
