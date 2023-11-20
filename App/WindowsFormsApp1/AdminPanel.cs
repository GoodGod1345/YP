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

namespace WindowsFormsApp1
{
    public partial class AdminPanel : Form
    {
        DataBase dataBase = new DataBase();
        public DataTable table;
        public SqlDataAdapter adapter;
        public SqlCommandBuilder builder;

        public AdminPanel()
        {
            InitializeComponent();
        }

        public void CreateTable(string sqlCommand)
        {
            dataBase.openConnection();
            table = new DataTable("dataGridView1");
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(sqlCommand, dataBase.getConnection());
            builder = new SqlCommandBuilder(adapter);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataBase.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e) //Маршруты
        {
            CreateTable("SELECT * FROM Маршрут");
        }

        private void button2_Click(object sender, EventArgs e) //Рейсы
        {
            CreateTable("select* from Рейс");
        }

        private void button3_Click(object sender, EventArgs e) //Ависудна
        {
            CreateTable("select * from Авиасудна");
        }

        private void button4_Click(object sender, EventArgs e) //КМД
        {
            CreateTable("select * from КомандирСудна");
        }

        private void button5_Click(object sender, EventArgs e) //Админы
        {
            CreateTable("select * from Admins");
        }

        private void button6_Click(object sender, EventArgs e) //История
        {
            CreateTable("select * from History");
        }

        private void button8_Click(object sender, EventArgs e) //Пассажиры
        {
            CreateTable("SELECT * FROM Пассажиры");
        }

        private void button7_Click(object sender, EventArgs e) //Сохранение
        {
            dataBase.openConnection();
            try
            {
                if (adapter != null && builder != null)
                {
                    adapter.Update(table);
                }
            }
            catch
            {
                MessageBox.Show("Упс! Вы наворотили херни с данными, поэтому они не сохранились. Исправте ошибки и попробуйте снова");
            }
            dataBase.closeConnection();
                    
        }
    }
}
