using EmployeeControlWinForms.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeControlWinForms
{
    public partial class AddEmployeeForm : Form
    {
        public int id;
        public NotifyIcon notify;
        public AddEmployeeForm()
        {
            InitializeComponent();
        }

        private void LoadData(string query, string[] invisibleColums)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                try
                {
                    adapter.Fill(ds, "YourTable");
                    dataGridView1.DataSource = ds.Tables["YourTable"];
                    foreach (string nameColumn in invisibleColums)
                    {
                        dataGridView1.Columns[nameColumn].Visible = false;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка подключения к базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            string[] columns = { "Id" };
            LoadData(DatabaseSettings.reliativesTable,
               columns
               );
        }
    }
}
