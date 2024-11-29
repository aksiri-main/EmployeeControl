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
    public partial class ROVDCorrectionCheckForm : Form
    {
        public NotifyIcon notify;
        public int id_city;
        public ROVDCorrectionCheckForm()
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

        private void ROVDCorrectionCheckForm_Load(object sender, EventArgs e)
        {
            string[] columns = { "Id", "Id_City" };
            LoadData(DatabaseSettings.rovdTable, columns);
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = (dataGridView1.SelectedRows[0]);
                AddEmployeeForm employeeForm = this.Owner as AddEmployeeForm;
                employeeForm.ROVDTextBox.Text = selectedRow.Cells["РОВД"].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите запись", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddROVDForm addROVDForm = new AddROVDForm();

            addROVDForm.notify = notify;
            addROVDForm.ShowDialog();
            ROVDCorrectionCheckForm_Load(sender, e);
        }
    }
}
