using System;
using MySql.Data.MySqlClient;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            numericUpDown3.Maximum = 3000;

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.pictureBox1, "Необходимо ввести серию и номер без пробелов");
            toolTip1.SetToolTip(this.pictureBox2, "Необходимо ввести серию и номер без пробелов");


            listView1.GridLines = true;

            listView1.FullRowSelect = true;

            listView1.View = View.Details;

            listView1.Columns.Add("");
            listView1.Columns.Add("Id");
            listView1.Columns.Add("Имя");
            listView1.Columns.Add("Фамилия");
            listView1.Columns.Add("Отчество");
            listView1.Columns.Add("Дата рождения");
            listView1.Columns.Add("Паспорт");
            listView1.Columns.Add("Курс");
            listView1.Columns.Add("Группа");
            listView1.Columns.Add("Сумма оплаты");

            DB db = new DB();

            DataTable table = new DataTable();

            db.open_connection();

            using (db.get_connection())
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `students_bkt`", db.get_connection());

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(new string[]
                        {
                        Convert.ToString(listView1.Items.Count+1),
                        Convert.ToString(reader.GetString("id")),
                        Convert.ToString(reader.GetString("name")),
                        Convert.ToString(reader.GetString("surname")),
                        Convert.ToString(reader.GetString("patronymic")),
                        Convert.ToString(reader.GetString("birthday")),
                        Convert.ToString(reader.GetString("passport")),
                        Convert.ToString(reader.GetString("year")),
                        Convert.ToString(reader.GetString("n_group")),
                        Convert.ToString(reader.GetString("payment_amount")),
                        });
                        listView1.Items.Add(item);
                    }
                }
                reader.Close();

            }

            db.close_connection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            DB db = new DB();

            DataTable table = new DataTable();

            db.open_connection();

            using (db.get_connection())
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `students_bkt`", db.get_connection());

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(new string[]
                        {
                        Convert.ToString(listView1.Items.Count+1),
                        Convert.ToString(reader.GetString("id")),
                        Convert.ToString(reader.GetString("name")),
                        Convert.ToString(reader.GetString("surname")),
                        Convert.ToString(reader.GetString("patronymic")),
                        Convert.ToString(reader.GetString("birthday")),
                        Convert.ToString(reader.GetString("passport")),
                        Convert.ToString(reader.GetString("year")),
                        Convert.ToString(reader.GetString("n_group")),
                        Convert.ToString(reader.GetString("payment_amount")),
                        });
                        listView1.Items.Add(item);
                    }
                }
                reader.Close();

            }

            db.close_connection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pass = check_pass.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `students_bkt` WHERE `passport` = @pass", db.get_connection());
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                MessageBox.Show("всё чики пуки");
            else
                MessageBox.Show("браза... капут...");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (check_student() == true)
            {
                MessageBox.Show("уже с нами");
                return;
            }

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `students_bkt` (`name`, `surname`, `patronymic`, `birthday`, `passport`, `year`, `n_group`, `payment_amount`) VALUES (@name, @surname, @patronymic, @birthday, @passport, @year, @n_group, @payment_amount);", db.get_connection());

            string birthday = numericUpDown1.Value.ToString() + "/" + numericUpDown2.Value.ToString() + "/" + numericUpDown3.Value.ToString();

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textbox_name.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textbox_surname.Text;
            command.Parameters.Add("@patronymic", MySqlDbType.VarChar).Value = textbox_patronymic.Text;
            command.Parameters.Add("@birthday", MySqlDbType.VarChar).Value = birthday;
            command.Parameters.Add("@passport", MySqlDbType.VarChar).Value = textbox_pass.Text;
            command.Parameters.Add("@year", MySqlDbType.VarChar).Value = textbox_year.Text;
            command.Parameters.Add("@n_group", MySqlDbType.VarChar).Value = textbox_group.Text;
            command.Parameters.Add("@payment_amount", MySqlDbType.VarChar).Value = textbox_pa.Text;

            db.open_connection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("добавил братан");
                button1_Click(sender, e);
            }
            else
                MessageBox.Show("чёт не пошло");

            db.close_connection();
        }

        public Boolean check_student()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `students_bkt` WHERE `passport` = @pass", db.get_connection());
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textbox_pass.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand delete = new MySqlCommand($"DELETE FROM `students_bkt` WHERE id = {listView1.SelectedItems[0].SubItems[1].Text}", db.get_connection());

            db.open_connection();

            if (delete.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("уволен");
                button1_Click(sender, e);
            }
            else
                MessageBox.Show("ладно, живи");

            db.close_connection();
        }
    }
}
