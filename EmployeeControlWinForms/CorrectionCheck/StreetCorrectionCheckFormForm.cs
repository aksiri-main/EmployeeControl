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
    public partial class StreetCorrectionCheckFormForm : Form
    {
        public NotifyIcon notify;
        public int id_city;
        public int location;
        public StreetCorrectionCheckFormForm()
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
        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = (dataGridView1.SelectedRows[0]);
                AddEmployeeForm employeeForm = this.Owner as AddEmployeeForm;
                if(location == 1)
                    employeeForm.StreetTextBox1.Text = selectedRow.Cells["Улица"].Value.ToString();
                else
                    employeeForm.StreetTextBox2.Text = selectedRow.Cells["Улица"].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите запись", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void StreetCorrectionCheckFormForm_Load(object sender, EventArgs e)
        {
            string[] columns = { "Id", "Id_City" };
            LoadData("SELECT Streets.Id, Id_City, Countries.name AS [Страна]," +
                    " Area.name AS [Область]," +
                    " Cities.name AS [Город]," +
                    " Streets.name AS [Улица]" +
                    " FROM Streets" +
                    " JOIN Cities ON Streets.Id_City = Cities.Id" +
                    " JOIN Area ON Cities.Id_Areas = Area.Id" +
                    " JOIN Countries ON Area.Id_Country = Countries.Id" +
                    $" WHERE Id_City = {id_city}", columns);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddStreetForm addStreet = new AddStreetForm();
            addStreet.notify = notify;
            addStreet.ShowDialog();
            StreetCorrectionCheckFormForm_Load(sender, e);
        }
    }
}
