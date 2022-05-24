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

        private void check_but_Click(object sender, EventArgs e)
        {
            Check_student cst = new Check_student();
            cst.Show();
        }

        private void add_but_Click(object sender, EventArgs e)
        {
            Add_student ast = new Add_student();
            ast.Show();
        }

        private void show_list_but_Click(object sender, EventArgs e)
        {
            Show_list_students sls = new Show_list_students();
            sls.Show();
        }
    }
}
