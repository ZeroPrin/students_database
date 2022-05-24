using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Add_student : Form
    {
        public Add_student()
        {
            InitializeComponent();
            textBox1.Text = "Введите имя";
            textBox2.Text = "Введите номер";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите имя" || textBox1.Text == "" || textBox2.Text == "Введите номер" || textBox2.Text == "")
            {
                MessageBox.Show("ты кого наебать пытаешься?");
                return;
            }

            if (check_student() == true)
            {
                MessageBox.Show("уже с нами");
                return;
            }

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `students` ( `name`, `num`) VALUES ( @name, @num);", db.get_connection());

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@num", MySqlDbType.VarChar).Value = textBox2.Text;

            db.open_connection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("добавил братан");
            else
                MessageBox.Show("чёт не пошло");


            db.close_connection();
        }

        public Boolean check_student() 
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `students` WHERE `name` = @ul", db.get_connection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "Введите имя";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                textBox2.Text = "Введите номер";
        }
    }
}
