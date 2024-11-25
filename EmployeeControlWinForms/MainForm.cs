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

namespace EmployeeControlWinForms
{
    public partial class MainForm : Form
    {
        string pageName;
        public MainForm()
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

        void MenuItemClick(string page,
            string query,
            string[] invisibleColumns)
        {
            pageName = page;
            this.Text = pageName;
            LoadData(query, invisibleColumns);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            switch (pageName)
            {
                case "Сотрудники":
                    AddEmployeeForm addEmployee = new AddEmployeeForm();
                    addEmployee.notify = notifyIcon1;
                    addEmployee.ShowDialog();
                    break;

                case "Страны":
                    AddCountryForm addCountry = new AddCountryForm();
                    addCountry.notify = notifyIcon1;
                    addCountry.ShowDialog();
                    break;

                case "Области":
                    {
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            DataGridViewRow selectedRow = (dataGridView1.SelectedRows[0]);
                            
                        }
                        else
                        {
                            MessageBox.Show("Выберите запись для добавления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] columns = { "Id" };
            MenuItemClick("Сотрудники", DatabaseSettings.employeeTable,
                columns
                );
        }

        private void страныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] columns = { "Id" };
            MenuItemClick("Страны", DatabaseSettings.countriesTable,
                columns
                );
            AddButton2.Visible = true;
            AddButton2.Text = "Добавить область";
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddButton2.Visible = false;
            string[] columns = { "Id" };
            MenuItemClick("Сотрудники", DatabaseSettings.employeeTable,
                columns
                );
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = (dataGridView1.SelectedRows[0]);
                switch (pageName)
                {
                    case "Сотрудники":
                        AddEmployeeForm addEmployee = new AddEmployeeForm();
                        addEmployee.Text = "Редактирование сотрудника";
                        addEmployee.AddButton.Text = "Изменить";
                        addEmployee.notify = notifyIcon1;

                        addEmployee.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                        addEmployee.NameTextBox.Text = selectedRow.Cells["Имя"].Value.ToString();
                        addEmployee.ShowDialog();
                        break;

                    case "Страны":
                        AddCountryForm addCountry = new AddCountryForm();
                        addCountry.Text = "Редактирование страны";
                        addCountry.AddButton.Text = "Изменить";
                        addCountry.notify = notifyIcon1;

                        addCountry.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                        addCountry.NameTextBox.Text = selectedRow.Cells["Наименование"].Value.ToString();
                        addCountry.ShowDialog();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для изменения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = (dataGridView1.SelectedRows[0]);
                switch (pageName)
                {
                    case "Страны":
                        SimpleAddAreaForm addArea = new SimpleAddAreaForm();
                        addArea.notify = notifyIcon1;

                        addArea.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                        addArea.ShowDialog();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для изменения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void областиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] columns = { "Id" };
            MenuItemClick("Страны", DatabaseSettings.countriesTable,
                columns
                );
            AddButton2.Visible = true;
            AddButton2.Text = "Добавить улицу";
        }
    }
}
