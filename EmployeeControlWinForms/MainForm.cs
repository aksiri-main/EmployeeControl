using EmployeeControlWinForms.AddForms;
using EmployeeControlWinForms.DB;
using EmployeeControlWinForms.SimpleAddForms;
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
                    сотрудникиToolStripMenuItem_Click(sender, e);
                    break;

                case "Страны":
                    AddCountryForm addCountry = new AddCountryForm();
                    addCountry.notify = notifyIcon1;
                    addCountry.ShowDialog();
                    страныToolStripMenuItem_Click(sender, e);
                    break;

                case "Области":
                    AddAreaForm addArea = new AddAreaForm();
                    addArea.notify = notifyIcon1;
                    addArea.ShowDialog();
                    областиToolStripMenuItem_Click(sender, e);
                    break;

                case "Города":
                    AddCityForm addCity = new AddCityForm();
                    addCity.notify = notifyIcon1;
                    addCity.ShowDialog();
                    городаToolStripMenuItem_Click(sender, e);
                    break;

                case "Улицы":
                    AddStreetForm addStreet = new AddStreetForm();
                    addStreet.notify = notifyIcon1;
                    addStreet.ShowDialog();
                    улицыToolStripMenuItem_Click(sender, e);
                    break;

                case "РОВД":
                    AddROVDForm addROVD = new AddROVDForm();
                    addROVD.notify = notifyIcon1;
                    addROVD.ShowDialog();
                    рОВДToolStripMenuItem_Click(sender, e);
                    break;

                case "Военные комиссариаты":
                    AddCommissariatForm addCommissariat = new AddCommissariatForm();
                    addCommissariat.notify = notifyIcon1;
                    addCommissariat.ShowDialog();
                    военныеКомисариатыToolStripMenuItem_Click(sender, e);
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
                        addEmployee.SurnameTextBox.Text = selectedRow.Cells["Фамилия"].Value.ToString();
                        addEmployee.NameTextBox.Text = selectedRow.Cells["Имя"].Value.ToString();
                        addEmployee.LastNameTextBox.Text = selectedRow.Cells["Отчество"].Value.ToString();
                        addEmployee.DateOfBirthdayDateTimePicker.Text = selectedRow.Cells["Дата рождения"].Value.ToString();
                        if(selectedRow.Cells["Пол"].Value.ToString() == "М")
                        {
                            addEmployee.ManRadioButton.Checked = true;
                        }
                        else
                        {
                            addEmployee.WomanRadioButton.Checked = true;
                        }
                        addEmployee.ShowDialog();
                        сотрудникиToolStripMenuItem_Click(sender, e);
                        break;

                    case "Страны":
                        AddCountryForm addCountry = new AddCountryForm();
                        addCountry.Text = "Редактирование страны";
                        addCountry.AddButton.Text = "Изменить";
                        addCountry.notify = notifyIcon1;

                        addCountry.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                        addCountry.NameTextBox.Text = selectedRow.Cells["Наименование"].Value.ToString();
                        addCountry.ShowDialog();
                        страныToolStripMenuItem_Click(sender, e);
                        break;

                    case "Области":
                        AddAreaForm addArea = new AddAreaForm();
                        addArea.Text = "Редактирование области";
                        addArea.AddButton.Text = "Изменить";
                        addArea.notify = notifyIcon1;

                        addArea.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                        addArea.CountriesComboBox.Text = selectedRow.Cells["Страна"].Value.ToString();
                        addArea.NameTextBox.Text = selectedRow.Cells["Область"].Value.ToString();
                        addArea.ShowDialog();
                        областиToolStripMenuItem_Click(sender, e);
                        break;

                    case "Города":
                        AddCityForm addCity = new AddCityForm();
                        addCity.Text = "Редактирование города";
                        addCity.AddButton.Text = "Изменить";
                        addCity.notify = notifyIcon1;

                        addCity.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                        addCity.CountriesComboBox.Text = selectedRow.Cells["Страна"].Value.ToString();
                        addCity.AreasComboBox.Text = selectedRow.Cells["Область"].Value.ToString();
                        addCity.NameTextBox.Text = selectedRow.Cells["Город"].Value.ToString();
                        addCity.ShowDialog();
                        городаToolStripMenuItem_Click(sender, e);
                        break;

                    case "Улицы":
                        AddStreetForm addStreet = new AddStreetForm();
                        addStreet.Text = "Редактирование улицы";
                        addStreet.AddButton.Text = "Изменить";
                        addStreet.notify = notifyIcon1;

                        addStreet.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                        addStreet.CountriesComboBox.Text = selectedRow.Cells["Страна"].Value.ToString();
                        addStreet.AreasComboBox.Text = selectedRow.Cells["Область"].Value.ToString();
                        addStreet.CitiesComboBox.Text = selectedRow.Cells["Город"].Value.ToString();
                        addStreet.NameTextBox.Text = selectedRow.Cells["Улица"].Value.ToString();
                        addStreet.ShowDialog();
                        улицыToolStripMenuItem_Click(sender, e);
                        break;

                    case "РОВД":
                        AddROVDForm addROVD = new AddROVDForm();
                        addROVD.Text = "Редактирование РОВД";
                        addROVD.AddButton.Text = "Изменить";
                        addROVD.notify = notifyIcon1;

                        addROVD.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                        addROVD.CountriesComboBox.Text = selectedRow.Cells["Страна"].Value.ToString();
                        addROVD.AreasComboBox.Text = selectedRow.Cells["Область"].Value.ToString();
                        addROVD.CitiesComboBox.Text = selectedRow.Cells["Город"].Value.ToString();
                        addROVD.NameTextBox.Text = selectedRow.Cells["РОВД"].Value.ToString();
                        addROVD.ShowDialog();
                        рОВДToolStripMenuItem_Click(sender, e);
                        break;

                    case "Военные комиссариаты":
                        AddCommissariatForm addCommissariat = new AddCommissariatForm();
                        addCommissariat.Text = "Редактирование комиссариата";
                        addCommissariat.AddButton.Text = "Изменить";
                        addCommissariat.notify = notifyIcon1;

                        addCommissariat.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                        addCommissariat.CountriesComboBox.Text = selectedRow.Cells["Страна"].Value.ToString();
                        addCommissariat.AreasComboBox.Text = selectedRow.Cells["Область"].Value.ToString();
                        addCommissariat.CitiesComboBox.Text = selectedRow.Cells["Город"].Value.ToString();
                        addCommissariat.NameTextBox.Text = selectedRow.Cells["Комиссариат"].Value.ToString();
                        addCommissariat.ShowDialog();
                        военныеКомисариатыToolStripMenuItem_Click(sender, e);
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

                        addArea.id_country = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                        addArea.ShowDialog();
                        break;

                    case "Области":
                        SimpleAddCityForm addCity = new SimpleAddCityForm();    
                        addCity.notify = notifyIcon1;

                        addCity.id_area = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                        addCity.ShowDialog();
                        break;

                    case "Города":
                        SimpleAddStreetForm addStreet = new SimpleAddStreetForm();
                        addStreet.notify = notifyIcon1;

                        addStreet.id_city = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                        addStreet.ShowDialog();
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
            string[] columns = { "Id", "Id_Country" };
            MenuItemClick("Области", DatabaseSettings.areasTable,
                columns
                );
            AddButton2.Visible = true;
            AddButton2.Text = "Добавить город";
        }

        private void городаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] columns = { "Id", "Id_Areas" };
            MenuItemClick("Города", DatabaseSettings.citiesTable,
                columns
                );
            AddButton2.Visible = true;
            AddButton2.Text = "Добавить улицу";
        }

        private void улицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] columns = { "Id", "Id_City" };
            MenuItemClick("Улицы", DatabaseSettings.streetsTable,
                columns
                );
            AddButton2.Visible = false;
        }

        private void рОВДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] columns = { "Id", "Id_City" };
            MenuItemClick("РОВД", DatabaseSettings.rovdTable,
                columns
                );
            AddButton2.Visible = false;
        }

        private void военныеКомисариатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] columns = { "Id", "Id_City" };
            MenuItemClick("Военные комиссариаты", DatabaseSettings.commissariatsTable,
                columns
                );
            AddButton2.Visible = false;
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (SearchTextBox.Text == "Поиск:")
            {
                SearchTextBox.Clear();
            }
        }

        private void SearchTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (SearchTextBox.Text == "Поиск:")
            {
                SearchTextBox.Text = "";
            }
        }

        private void SearchTextBox_MouseLeave(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "")
            {
                SearchTextBox.Text = "Поиск:";
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            if (SearchTextBox.Text.Length > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Contains(SearchTextBox.Text.ToLower()))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = (dataGridView1.SelectedRows[0]);
                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                switch (pageName)
                {
                    case "Сотрудники":
                        using (SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString))
                        {
                            connection.Open();
                            SqlTransaction transaction = connection.BeginTransaction();
                            try
                            {
                                AddRecords.DeletingRecordsFromTheDataBase(id, "DELETE FROM Reliatives WHERE Id_Employee = @KeyValue");
                                AddRecords.DeletingRecordsFromTheDataBase(id, "DELETE FROM MilitaryRegistration WHERE Id = @KeyValue");
                                AddRecords.DeletingRecordsFromTheDataBase(id, "DELETE FROM PlaceOfResidence WHERE Id = @KeyValue");
                                AddRecords.DeletingRecordsFromTheDataBase(id, "DELETE FROM RegistrationAddress WHERE Id = @KeyValue");
                                AddRecords.DeletingRecordsFromTheDataBase(id, "DELETE FROM Passport WHERE Id = @KeyValue");
                                AddRecords.DeletingRecordsFromTheDataBase(id, "DELETE FROM Employees WHERE Id = @KeyValue");
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show(ex.Message);
                            }
                        }
                        AddRecords.DeletingRecordsFromTheDataBase(id, "DELETE FROM Employees WHERE Id = @KeyValue");
                        сотрудникиToolStripMenuItem_Click(sender, e);
                        break;

                    case "Страны":
                        AddRecords.DeletingRecordsFromTheDataBase(id, "DELETE FROM Countries WHERE Id = @KeyValue");
                        страныToolStripMenuItem_Click(sender, e);
                        break;

                    case "Области":
                        AddRecords.DeletingRecordsFromTheDataBase(id, "DELETE FROM Area WHERE Id = @KeyValue");
                        областиToolStripMenuItem_Click(sender, e);
                        break;

                    case "Города":
                        AddRecords.DeletingRecordsFromTheDataBase(id, "DELETE FROM Cities WHERE Id = @KeyValue");
                        городаToolStripMenuItem_Click(sender, e);
                        break;

                    case "Улицы":
                        AddRecords.DeletingRecordsFromTheDataBase(id, "DELETE FROM Streets WHERE Id = @KeyValue");
                        улицыToolStripMenuItem_Click(sender, e);
                        break;

                    case "РОВД":
                        AddRecords.DeletingRecordsFromTheDataBase(id, "DELETE FROM ROVD WHERE Id = @KeyValue");
                        рОВДToolStripMenuItem_Click(sender, e);
                        break;

                    case "Военные комиссариаты":
                        AddRecords.DeletingRecordsFromTheDataBase(id, "DELETE FROM Comissariat WHERE Id = @KeyValue");
                        военныеКомисариатыToolStripMenuItem_Click(sender, e);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
