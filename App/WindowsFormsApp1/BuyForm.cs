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
    public partial class BuyForm : Form
    {
        DataBase dataBase = new DataBase();
        public BuyForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Ошибка! Поля с пометкой * обязательны к заполнению");
                return;
            }

            if (textBox4.Text == "")
                textBox4.Text = "NULL";

            if (textBox5.Text == "")
                textBox5.Text = "NULL";

            dataBase.openConnection();
            var addQuery = $"INSERT INTO Пассажиры (НомерПаспорта, [№Рейса], ФИО, АДРЕС, ТЕЛЕФОН) VALUES ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}')";
            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();
            dataBase.closeConnection();
        }
    }
}
