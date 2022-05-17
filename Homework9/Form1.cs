using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Homework9
{
    public partial class Form1 : Form
    {
        SQLiteConnection m_dbConnection;
        SQLiteDataAdapter m_adapter;
        DataSet m_dataSet;
        int m_index = 0;
        string wordAnswer = "";

        public Form1()
        {
            InitializeComponent();
            InitSQL();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputAnswer = textBox1.Text;
            if(checkAnswer(inputAnswer))
            {
                MessageBox.Show("正确");
                m_index++;
                if(m_index >= m_dataSet.Tables[0].Rows.Count)
                {
                    m_index = 0;
                    wordAnswer = m_dataSet.Tables[0].Rows[0][1].ToString();
                    MessageBox.Show("已完成全部");
                }
                wordAnswer = m_dataSet.Tables[0].Rows[m_index][1].ToString();
                textBox1.Text = String.Empty;
                label1.Text = m_dataSet.Tables[0].Rows[m_index][2].ToString();
            }
            else
            {
                MessageBox.Show("错误!");
            }
        }

        private bool checkAnswer(string inputWord)
        {
            if (inputWord.Replace(" ","") == wordAnswer)
            {
                return true;
            }
            return false;
        }

        private void InitSQL()
        {
            //connect
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.db");
            m_dbConnection.Open();
            //create table
            string sql = "create table if not exists dict (no int, word VARCHAR(20), meaning NVARCHAR(50), UNIQUE(word))";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            //insert data
            sql = "insert or ignore into dict values (1, 'abandon', '遗弃，抛弃')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert or ignore into dict values (2, 'baby', '婴儿；孩子气的人')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert or ignore into dict values (3, 'cab', '计程车，出租汽车')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert or ignore into dict values (4, 'dance', '舞蹈')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert or ignore into dict values (5, 'each', '每个')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert or ignore into dict values (6, 'facility', '设施')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            //sql test
            /*
            sql = "select * from dict order by no desc";
            command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Word: " + reader["word"] + "\nMeaning: " + reader["meaning"]);
            Console.ReadLine();
            */
        }

        private void LoadData()
        {
            string sql = "select * from dict";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            m_adapter = new SQLiteDataAdapter(command);
            m_dataSet = new DataSet();
            m_adapter.Fill(m_dataSet, "dict");
            m_dbConnection.Close();
            m_index = 0;
            wordAnswer = m_dataSet.Tables[0].Rows[0][1].ToString();
            label1.Text = m_dataSet.Tables[0].Rows[0][2].ToString();
        }
    }
}
