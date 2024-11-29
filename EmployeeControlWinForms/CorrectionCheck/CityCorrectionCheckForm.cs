using EmployeeControlWinForms.AddForms;
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

namespace EmployeeControlWinForms.CorrectionCheck
{
    public partial class CityCorrectionCheckForm : Form
    {
        public NotifyIcon notify;
        public int id_country;
        public int location;
        public CityCorrectionCheckForm()
        {
            InitializeComponent();
        }

        private void LoadData(string query, string[] invisibleColumns)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                //try
                //{
                adapter.Fill(ds, "YourTable");
                dataGridView1.DataSource = ds.Tables["YourTable"];
                foreach (string nameColumn in invisibleColumns)
                {
                    dataGridView1.Columns[nameColumn].Visible = false;
                }
                //}
                //catch
                //{
                //    MessageBox.Show("Ошибка подключения к базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        private void CityCorrectionCheckForm_Load(object sender, EventArgs e)
        {
            string[] columns = { "Id", "Id_Areas" };
            LoadData("SELECT Cities.Id, Id_Areas, Countries.name AS [Страна]," +
                     " Area.name AS [Область]," +
                     " Cities.name AS [Город]" +
                     " FROM Cities" +
                     " JOIN Area ON Cities.Id_Areas = Area.Id" +
                     " JOIN Countries ON Area.Id_Country = Countries.Id" +
                     $" WHERE Id_Country = {id_country}", columns);
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = (dataGridView1.SelectedRows[0]);
                AddEmployeeForm employeeForm = this.Owner as AddEmployeeForm;
                if(location == 1)
                    employeeForm.CityTextBox1.Text = selectedRow.Cells["Город"].Value.ToString();
                else
                    employeeForm.CityTextBox2.Text = selectedRow.Cells["Город"].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите запись", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddCityForm addCity = new AddCityForm();
            addCity.notify = notify;
            addCity.ShowDialog();
            CityCorrectionCheckForm_Load(sender, e);
        }
    }
}
