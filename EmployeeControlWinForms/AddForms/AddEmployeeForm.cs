using EmployeeControlWinForms.AddForms;
using EmployeeControlWinForms.CorrectionCheck;
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
        Dictionary<String, int> countriesDictionary = new Dictionary<String, int>();
        Dictionary<String, int> citiesDictionary = new Dictionary<String, int>();
        Dictionary<String, int> streetsDictionary = new Dictionary<String, int>();
        Dictionary<String, int> rovdDictionary = new Dictionary<String, int>();
        Dictionary<String, int> commissariatDictionary = new Dictionary<String, int>();
        public AddEmployeeForm()
        {
            InitializeComponent();
            AddRecords.FillComboBox("SELECT name, Id FROM Countries", CounrtyComboBox1, countriesDictionary);
            FillComboBox(CounrtyComboBox2, countriesDictionary);
            AddRecords.FillDictionary("SELECT name, Id FROM ROVD", rovdDictionary);
            AddRecords.FillDictionary("SELECT name, Id FROM Comissariat", commissariatDictionary);
            AddRecords.FillDictionary("SELECT name, Id FROM Cities", citiesDictionary);
            CounrtyComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        void FillComboBox(ComboBox comboBox, Dictionary<String, int> keyValues)
        {
            comboBox.Items.Clear();
            foreach(var item in keyValues)
            {
                comboBox.Items.Add(item.Key);
            }
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            string[] columns = { "Id" };
            LoadData(DatabaseSettings.reliativesTable,
               columns
               );
        }

        private void LoadData(string query, string[] invisibleColumns)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                try
                {
                    adapter.Fill(ds, "YourTable");
                    dataGridView1.DataSource = ds.Tables["YourTable"];
                    foreach (string nameColumn in invisibleColumns)
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
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string RBCheck()
        {
            if (ManRadioButton.Checked)
            {
                return "М";
            }
            else
            {
                return "Ж";
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string uniquenessQuery;
            countriesDictionary.TryGetValue(CounrtyComboBox1.Text, out int id_country);
            rovdDictionary.TryGetValue(ROVDTextBox.Text, out int id_rovd);
            commissariatDictionary.TryGetValue(MilitaryCommissariatTextBox.Text, out int id_commissariat);
            countriesDictionary.TryGetValue(CounrtyComboBox1.Text, out int id_country_for_registration_address);
            countriesDictionary.TryGetValue(CounrtyComboBox2.Text, out int id_country_for_place_of_residence);
            citiesDictionary.TryGetValue(CityTextBox1.Text, out int id_city_for_registration_address);
            citiesDictionary.TryGetValue(CityTextBox2.Text, out int id_city_for_place_of_residence);
            streetsDictionary.TryGetValue(StreetTextBox1.Text, out int id_street_for_registration_address);
            streetsDictionary.TryGetValue(StreetTextBox2.Text, out int id_street_for_place_of_residence);
            string[] strings = { NameTextBox.Text, SurnameTextBox.Text, LastNameTextBox.Text };
            string queryEmployee;
            string queryPassport;
            string queryMilitary;
            string queryRegistrationAddress;
            string queryPlaceOfResidence;

            if (AddButton.Text != "Изменить")
            {
                queryEmployee = "INSERT INTO [Employees] (name, surname, lastName, dateOfBirthday, sex) VALUES (@value1, @value2, @value3, @value4, @value5)";
                queryPassport = "INSERT INTO [Passport] (Id_ROVD, serial, number, fromDate, toDate) VALUES (@value1, @value2, @value3, @value4, @value5)";
                queryMilitary = "INSERT INTO [MilitaryRegistration] (Id_Comissariat, stockCategory, militaryRank, сomposition, codeVUS, suitabilityCategory, militaryAccounting, markAccounting)" +
                                " VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8)";
                queryRegistrationAddress = "INSERT INTO [RegistrationAddress] (Id_Country, Id_City, Id_Street, index, house, apartament, phoneNumber)" +
                    " VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7)";
                queryPlaceOfResidence = "INSERT INTO [PlaceOfResidence] (Id_Country, Id_City, Id_Street, index, house, apartament, phoneNumber)" +
                    " VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7)";

                uniquenessQuery = "SELECT COUNT(*) FROM Employees WHERE (name = @value1 AND surname = @value2 AND lastName = @value3)";
            }
            else
            {
                queryEmployee = "UPDATE Employees SET name=@value1, surname=@value2, lastName=@value3, dateOfBirthday=@value4, sex=@value5 WHERE Id=@id";
                queryPassport = "UPDATE Passport SET Id_ROVD=@value1, name=@value2 WHERE Id=@id";
                queryMilitary = "UPDATE Employees SET Id_City=@value1, name=@value2 WHERE Id=@id";
                queryRegistrationAddress = "UPDATE RegistrationAddress SET Id_Country=@value1, Id_City=@value2, Id_Street=@value3," +
                    " index=@value4, house=@value5, apartament=@value6, phoneNumber=@value7";
                queryPlaceOfResidence = "UPDATE PlaceOfResidence SET Id_Country=@value1, Id_City=@value2, Id_Street=@value3," +
                    " index=@value4, house=@value5, apartament=@value6, phoneNumber=@value7";

                uniquenessQuery = $"SELECT COUNT(*) FROM Streets WHERE (Id_City = @value1 AND name = @value2) AND id != '{id}'";
            }
            int result = AddRecords.UniquenessCheck(
                uniquenessQuery,
                AddRecords.PutStringValuesIntoArray(strings)
                );

            if (result == 0)
            {
                if (NameTextBox.Text == "")
                {
                    AddRecords.NotifyIconSettings(notify, ToolTipIcon.Warning, "Внимание!", "Необходимо заполнить наименование!", 3);
                    return;
                }

                string[] valuesEmployee = { NameTextBox.Text, SurnameTextBox.Text, LastNameTextBox.Text, DateOfBirthdayDateTimePicker.Text, RBCheck() };
                string[] valuesPassport = { id_rovd.ToString(), SerialTextBox.Text, NumberTextBox.Text, FromDateTimePicker.Text, ToDateTimePicker.Text };
                string[] valuesMilitary = { id_commissariat.ToString(), StockCategoryTextBox.Text, MilitaryRankTextBox.Text,
                    CompositionTextBox.Text, CodeVUSTextBox.Text, SuitabilityCategoryTextBox.Text,
                    MilitaryAccountingTextBox.Text, MarkAccountingTextBox.Text
                };
                string[] valuesRegistrationAddress = { 
                    id_country_for_registration_address.ToString(),
                    id_city_for_registration_address.ToString(),
                    id_street_for_registration_address.ToString(),
                    IndexTextBox1.Text,
                    HouseTextBox1.Text,
                    ApartamentTextBox1.Text,
                    PhoneNumberTextBox1.Text
                };
                string[] valuesPlaceOfResidence = {
                    id_country_for_place_of_residence.ToString(),
                    id_city_for_place_of_residence.ToString(),
                    id_street_for_place_of_residence.ToString(),
                    IndexTextBox2.Text,
                    HouseTextBox2.Text,
                    ApartamentTextBox2.Text,
                    PhoneNumberTextBox2.Text
                };


                using (SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        AddRecords.AddRecordsMethod(
                            queryEmployee,
                            AddRecords.PutStringValuesIntoArray(valuesEmployee),
                            id,
                            connection,
                            transaction
                            );

                        AddRecords.AddRecordsMethod(
                            queryPassport,
                            AddRecords.PutStringValuesIntoArray(valuesPassport),
                            id,
                            connection,
                            transaction
                            );

                        AddRecords.AddRecordsMethod(
                            queryMilitary,
                            AddRecords.PutStringValuesIntoArray(valuesMilitary),
                            id,
                            connection,
                            transaction
                            );

                        AddRecords.AddRecordsMethod(
                            queryRegistrationAddress,
                            AddRecords.PutStringValuesIntoArray(valuesRegistrationAddress),
                            id,
                            connection,
                            transaction
                            );

                        AddRecords.AddRecordsMethod(
                            queryPlaceOfResidence,
                            AddRecords.PutStringValuesIntoArray(valuesPlaceOfResidence),
                            id,
                            connection,
                            transaction
                            );

                        transaction.Commit();
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                        transaction.Rollback();
                    }
                }

                this.Close();
            }
        }

        private void StreetTextBox1_Leave(object sender, EventArgs e)
        {
            citiesDictionary.TryGetValue(CityTextBox1.Text, out var id_city);
            string[] strings = { StreetTextBox1.Text };
            int result = AddRecords.UniquenessCheck(
                $"SELECT Count(*) FROM Streets" +
                $" WHERE (name=@value1 AND Id_City = {id_city})",
                AddRecords.PutStringValuesIntoArray(strings)
                );
            if (result == 0)
            {
                StreetCorrectionCheckFormForm streetCorrection = new StreetCorrectionCheckFormForm();
                streetCorrection.notify = notify;
                streetCorrection.id_city = id_city;
                streetCorrection.location = 1;
                streetCorrection.ShowDialog(this);
            }
        }

        private void CityTextBox1_Leave(object sender, EventArgs e)
        {
            countriesDictionary.TryGetValue(CounrtyComboBox1.Text, out var id_country);
            string[] strings = { CityTextBox1.Text };
            int result = AddRecords.UniquenessCheck(
                $"SELECT Count(*) FROM Cities" +
                $" JOIN Area ON Cities.Id_Areas = Area.Id" +
                $" WHERE (Cities.name=@value1 AND Area.Id_Country = {id_country})",
                AddRecords.PutStringValuesIntoArray(strings)
                );
            if (result == 0)
            {
                CityCorrectionCheckForm cityCorrection = new CityCorrectionCheckForm();
                cityCorrection.notify = notify;
                cityCorrection.id_country = id_country;
                cityCorrection.location = 1;
                cityCorrection.ShowDialog(this);
            }
        }

        private void ROVDTextBox_Leave(object sender, EventArgs e)
        {
            string[] strings = { ROVDTextBox.Text };
            int result = AddRecords.UniquenessCheck(
                "SELECT COUNT(*) FROM ROVD" +
                " WHERE name=@value1",
                AddRecords.PutStringValuesIntoArray(strings)
                );
            if (result == 0)
            {
                ROVDCorrectionCheckForm rovdCorrection = new ROVDCorrectionCheckForm();

                rovdCorrection.notify = notify;
                rovdCorrection.ShowDialog(this);
            }
        }

        private void MilitaryCommissariatTextBox_Leave(object sender, EventArgs e)
        {
            string[] strings = { MilitaryCommissariatTextBox.Text };
            int result = AddRecords.UniquenessCheck(
                "SELECT COUNT(*) FROM Comissariat" +
                " WHERE name=@value1",
                AddRecords.PutStringValuesIntoArray(strings)
                );
            if (result == 0)
            {
                CommissariatCorrectionCheckForm commissariatCorrection = new CommissariatCorrectionCheckForm();
                
                commissariatCorrection.notify = notify;
                commissariatCorrection.ShowDialog(this);
            }
        }

        private void CityTextBox2_Leave(object sender, EventArgs e)
        {
            countriesDictionary.TryGetValue(CounrtyComboBox2.Text, out var id_country);
            string[] strings = { CityTextBox2.Text };
            int result = AddRecords.UniquenessCheck(
                $"SELECT Count(*) FROM Cities" +
                $" JOIN Area ON Cities.Id_Areas = Area.Id" +
                $" WHERE (Cities.name=@value1 AND Area.Id_Country = {id_country})",
                AddRecords.PutStringValuesIntoArray(strings)
                );
            if (result == 0)
            {
                CityCorrectionCheckForm cityCorrection = new CityCorrectionCheckForm();
                cityCorrection.notify = notify;
                cityCorrection.id_country = id_country;
                cityCorrection.location = 2;
                cityCorrection.ShowDialog(this);
            }
        }

        private void StreetTextBox2_Leave(object sender, EventArgs e)
        {
            citiesDictionary.TryGetValue(CityTextBox2.Text, out var id_city);
            string[] strings = { StreetTextBox2.Text };
            int result = AddRecords.UniquenessCheck(
                $"SELECT Count(*) FROM Streets" +
                $" WHERE (name=@value1 AND Id_City = {id_city})",
                AddRecords.PutStringValuesIntoArray(strings)
                );
            if (result == 0)
            {
                StreetCorrectionCheckFormForm streetCorrection = new StreetCorrectionCheckFormForm();
                streetCorrection.notify = notify;
                streetCorrection.id_city = id_city;
                streetCorrection.location = 2;
                streetCorrection.ShowDialog(this);
            }
        }
    }
}
