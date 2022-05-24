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
    public partial class Show_list_students : Form
    {
        public Show_list_students()
        {
            InitializeComponent();
        }

        private void Show_list_students_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;

            listView1.FullRowSelect = true;

            listView1.View = View.Details;

            listView1.Columns.Add("");
            listView1.Columns.Add("Id");
            listView1.Columns.Add("Имя");
            listView1.Columns.Add("Число");

            DB db = new DB();

            DataTable table = new DataTable();

            db.open_connection();

            using (db.get_connection()) 
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `students`", db.get_connection());

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
                        Convert.ToString(reader.GetString("num")),
                        });
                        listView1.Items.Add(item);
                    }
                }
                reader.Close();

            }

            db.close_connection();

        }
    }
}
