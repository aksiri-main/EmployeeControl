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
            AddRecords.FillDictionary("SELECT name, Id FROM Streets", streetsDictionary);
            CounrtyComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        void FillComboBox(ComboBox comboBox, Dictionary<String, int> keyValues)
        {
            comboBox.Items.Clear();
            foreach (var item in keyValues)
            {
                comboBox.Items.Add(item.Key);
            }
        }

        void Validation()
        {
            DateOfBirthdayDateTimePicker.MaxDate = DateTime.Now.AddYears(-14);
            DateOfBirthdayDateTimePicker.MinDate = DateTime.Now.AddYears(-100);
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            Validation();
            if (AddButton.Text == "Изменить")
            {
                string[] columns = { "Id" };
                LoadData("SELECT Id, kinship AS [Степень родства]," +
                         " surname AS 'Фамилия', name AS 'Имя', lastName AS 'Отчество'," +
                         " dateOfBirthday AS [Дата рождения] FROM Reliatives" +
                         $" WHERE Id_Employee = {id}",
                   columns
                   );
                EditFill();
            }
            else
            {
                string[] columns = { "Id" };
                LoadData("SELECT Id, kinship AS [Степень родства]," +
                         " surname AS 'Фамилия', name AS 'Имя', lastName AS 'Отчество'," +
                         " dateOfBirthday AS [Дата рождения] FROM Reliatives" +
                         $" WHERE Id_Employee = {id}",
                   columns
                   );
            }
        }

        void EditFill()
        {
            //Паспорт
            SerialTextBox.Text = AddRecords.FillText($"SELECT serial FROM Passport WHERE id = {id}");
            NumberTextBox.Text = AddRecords.FillText($"SELECT number FROM Passport WHERE id = {id}");
            IdentityNumberTextBox.Text = AddRecords.FillText($"SELECT identityNumber FROM Passport WHERE id = {id}");
            FromDateTimePicker.Text = AddRecords.FillText($"SELECT fromDate FROM Passport WHERE id = {id}");
            ToDateTimePicker.Text = AddRecords.FillText($"SELECT toDate FROM Passport WHERE id = {id}");
            ROVDTextBox.Text = AddRecords.FillText($"SELECT ROVD.name FROM Passport" +
                $" JOIN ROVD ON Passport.Id_ROVD = ROVD.Id WHERE Passport.id = {id}");

            //Адрес прописки
            IndexTextBox1.Text = AddRecords.FillText($"SELECT mailIndex FROM RegistrationAddress WHERE id = {id}");
            CounrtyComboBox1.Text = AddRecords.FillText($"SELECT Countries.name FROM RegistrationAddress" +
                $" JOIN Countries ON RegistrationAddress.Id_Country = Countries.Id WHERE RegistrationAddress.id = {id}");
            CityTextBox1.Text = AddRecords.FillText($"SELECT Cities.name FROM RegistrationAddress" +
                $" JOIN Cities ON RegistrationAddress.Id_City = Cities.Id WHERE RegistrationAddress.id = {id}");
            StreetTextBox1.Text = AddRecords.FillText($"SELECT Streets.name FROM RegistrationAddress" +
                $" JOIN Streets ON RegistrationAddress.Id_Street = Streets.Id WHERE RegistrationAddress.id = {id}");
            HouseTextBox1.Text = AddRecords.FillText($"SELECT house FROM RegistrationAddress WHERE id = {id}");
            ApartamentTextBox1.Text = AddRecords.FillText($"SELECT apartament FROM RegistrationAddress WHERE id = {id}");
            PhoneNumberTextBox1.Text = AddRecords.FillText($"SELECT phoneNumber FROM RegistrationAddress WHERE id = {id}");

            //Место жительства
            IndexTextBox2.Text = AddRecords.FillText($"SELECT mailIndex FROM PlaceOfResidence WHERE id = {id}");
            CounrtyComboBox2.Text = AddRecords.FillText($"SELECT Countries.name FROM PlaceOfResidence" +
                $" JOIN Countries ON PlaceOfResidence.Id_Country = Countries.Id WHERE PlaceOfResidence.id = {id}");
            CityTextBox2.Text = AddRecords.FillText($"SELECT Cities.name FROM PlaceOfResidence" +
                $" JOIN Cities ON PlaceOfResidence.Id_City = Cities.Id WHERE PlaceOfResidence.id = {id}");
            StreetTextBox2.Text = AddRecords.FillText($"SELECT Streets.name FROM PlaceOfResidence" +
                $" JOIN Streets ON PlaceOfResidence.Id_Street = Streets.Id WHERE PlaceOfResidence.id = {id}");
            HouseTextBox2.Text = AddRecords.FillText($"SELECT house FROM PlaceOfResidence WHERE id = {id}");
            ApartamentTextBox2.Text = AddRecords.FillText($"SELECT apartament FROM PlaceOfResidence WHERE id = {id}");
            PhoneNumberTextBox2.Text = AddRecords.FillText($"SELECT phoneNumber FROM PlaceOfResidence WHERE id = {id}");

            //Воинский учет
            StockCategoryTextBox.Text = AddRecords.FillText($"SELECT stockCategory FROM MilitaryRegistration WHERE id = {id}");
            MilitaryRankTextBox.Text = AddRecords.FillText($"SELECT militaryRank FROM MilitaryRegistration WHERE id = {id}");
            CompositionTextBox.Text = AddRecords.FillText($"SELECT сomposition FROM MilitaryRegistration WHERE id = {id}");
            CodeVUSTextBox.Text = AddRecords.FillText($"SELECT codeVUS FROM MilitaryRegistration WHERE id = {id}");
            SuitabilityCategoryTextBox.Text = AddRecords.FillText($"SELECT suitabilityCategory FROM MilitaryRegistration WHERE id = {id}");
            MilitaryCommissariatTextBox.Text = AddRecords.FillText($"SELECT Comissariat.name FROM MilitaryRegistration" +
                $" JOIN Comissariat ON MilitaryRegistration.ID_Comissariat = Comissariat.id WHERE MilitaryRegistration.id = {id}");
            SpecialRadioButton.Checked = Convert.ToBoolean(AddRecords.FillTextBool($"SELECT militaryAccountingBool FROM MilitaryRegistration WHERE id = {id}"));
            MilitaryAccountingTextBox.Text = AddRecords.FillText($"SELECT militaryAccounting FROM MilitaryRegistration WHERE id = {id}");
            MarkAccountingTextBox.Text = AddRecords.FillText($"SELECT markAccounting FROM MilitaryRegistration WHERE id = {id}");
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
            if(ROVDTextBox.Text == "")
            {
                ROVDTextBox.Focus();
            }
            else if(CounrtyComboBox1.Text == "")
            {
                CounrtyComboBox1.Focus();
            }
            else if(CityTextBox1.Text == "")
            {
                CityTextBox1.Focus();
            }
            else if(StreetTextBox1.Text == "")
            {
                StreetTextBox1.Focus();
            }
            else if(CounrtyComboBox2.Text == "")
            {
                CounrtyComboBox2.Focus();
            }
            else if(CityTextBox2.Text == "")
            {
                CityTextBox2.Focus();
            }
            else if(MilitaryCommissariatTextBox.Text == "")
            {
                MilitaryCommissariatTextBox.Focus();
            }
            else
            {
                int id_employee;
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
                    queryPassport = "INSERT INTO [Passport] (Id, Id_ROVD, serial, number, fromDate, toDate, identityNumber) VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7)";
                    queryMilitary = "INSERT INTO [MilitaryRegistration] (Id, Id_Comissariat, stockCategory, militaryRank, сomposition, codeVUS, suitabilityCategory, militaryAccountingBool, militaryAccounting, markAccounting)" +
                                    " VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9, @value10)";
                    queryRegistrationAddress = "INSERT INTO [RegistrationAddress] (Id, Id_Country, Id_City, Id_Street, mailIndex, house, apartament, phoneNumber)" +
                        " VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8)";
                    queryPlaceOfResidence = "INSERT INTO [PlaceOfResidence] (Id,Id_Country, Id_City, Id_Street, mailIndex, house, apartament, phoneNumber)" +
                        " VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8)";

                    uniquenessQuery = "SELECT COUNT(*) FROM Employees WHERE (name = @value1 AND surname = @value2 AND lastName = @value3)";
                }
                else
                {
                    queryEmployee = "UPDATE Employees SET name=@value1, surname=@value2, lastName=@value3, dateOfBirthday=@value4, sex=@value5 WHERE Id=@id";
                    queryPassport = "UPDATE Passport SET Id_ROVD=@value2, serial=@value3, number=@value4, fromDate=@value5, toDate=@value6, identityNumber=@value7 WHERE Id=@id";
                    queryMilitary = "UPDATE MilitaryRegistration SET Id_Comissariat=@value2, stockCategory=@value3, militaryRank=@value4," +
                        " сomposition=@value5, codeVUS=@value6, suitabilityCategory=@value7, militaryAccountingBool=@value8, militaryAccounting=@value9, markAccounting=@value10 WHERE Id=@id";
                    queryRegistrationAddress = "UPDATE RegistrationAddress SET Id_Country=@value2, Id_City=@value3, Id_Street=@value4," +
                        " mailIndex=@value5, house=@value6, apartament=@value7, phoneNumber=@value8";
                    queryPlaceOfResidence = "UPDATE PlaceOfResidence SET Id_Country=@value2, Id_City=@value3, Id_Street=@value4," +
                        " mailIndex=@value5, house=@value6, apartament=@value7, phoneNumber=@value8";

                    uniquenessQuery = $"SELECT COUNT(*) FROM Employees WHERE (name = @value1 AND surname = @value2 AND lastName = @value3) AND id != '{id}'";
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

                    AddRecords.AddRecordsMethod(
                        queryEmployee,
                        AddRecords.PutStringValuesIntoArray(valuesEmployee),
                        AddButton.Text,
                        notify,
                        id
                        );

                    id_employee = AddRecords.CorrectionCheck(
                        "SELECT Id FROM Employees WHERE" +
                        " (name=@value1 AND surname=@value2 AND lastName=@value3 AND dateOfBirthday=@value4 AND sex=@value5)",
                        AddRecords.PutStringValuesIntoArray(valuesEmployee)
                        );

                    string[] valuesPassport = { id_employee.ToString(), id_rovd.ToString(), SerialTextBox.Text, NumberTextBox.Text, FromDateTimePicker.Text, ToDateTimePicker.Text, IdentityNumberTextBox.Text };
                    string[] valuesMilitary = { id_employee.ToString(), id_commissariat.ToString(), StockCategoryTextBox.Text, MilitaryRankTextBox.Text,
                    CompositionTextBox.Text, CodeVUSTextBox.Text, SuitabilityCategoryTextBox.Text,
                    GeneralRadioButton.Checked.ToString(), MilitaryAccountingTextBox.Text, MarkAccountingTextBox.Text
                };
                    string[] valuesRegistrationAddress = {
                            id_employee.ToString(),
                            id_country_for_registration_address.ToString(),
                            id_city_for_registration_address.ToString(),
                            id_street_for_registration_address.ToString(),
                            IndexTextBox1.Text,
                            HouseTextBox1.Text,
                            ApartamentTextBox1.Text,
                            PhoneNumberTextBox1.Text
                        };
                    string[] valuesPlaceOfResidence = {
                            id_employee.ToString(),
                            id_country_for_place_of_residence.ToString(),
                            id_city_for_place_of_residence.ToString(),
                            id_street_for_place_of_residence.ToString(),
                            IndexTextBox2.Text,
                            HouseTextBox2.Text,
                            ApartamentTextBox2.Text,
                            PhoneNumberTextBox2.Text
                        };

                    AddRecords.AddRecordsMethod(
                        queryPassport,
                        AddRecords.PutStringValuesIntoArray(valuesPassport),
                        id
                        );

                    AddRecords.AddRecordsMethod(
                        queryMilitary,
                        AddRecords.PutStringValuesIntoArray(valuesMilitary),
                        id
                        );

                    AddRecords.AddRecordsMethod(
                        queryRegistrationAddress,
                        AddRecords.PutStringValuesIntoArray(valuesRegistrationAddress),
                        id
                        );

                    AddRecords.AddRecordsMethod(
                        queryPlaceOfResidence,
                        AddRecords.PutStringValuesIntoArray(valuesPlaceOfResidence),
                        id
                        );

                    using (SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString))
                    {
                        connection.Open();
                        SqlTransaction transaction = connection.BeginTransaction();
                        try
                        {
                            if (AddButton.Text == "Изменить")
                            {
                                AddRecords.DeletingRecordsFromTheDataBase(id, "DELETE FROM Reliatives WHERE Id_Employee = @KeyValue", connection, transaction);
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                int count = 0;
                                string line = "";
                                Dictionary<string, string> cells = new Dictionary<string, string>();

                                if (!row.IsNewRow)
                                {
                                    cells.Add($"@value1", id_employee.ToString());
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        if (cell.Value != null)
                                        {
                                            count++;
                                            if (count != 1)
                                                cells.Add($"@value{count}", cell.Value.ToString());
                                        }
                                    }


                                    AddRecords.AddRecordsMethod(
                                        "INSERT INTO Reliatives (Id_Employee, kinship, name, surname, lastName, dateOfBirthday) VALUES (@value1, @value2, @value3, @value4, @value5, @value6)",
                                        cells,
                                        id,
                                        connection,
                                        transaction
                                    );

                                }

                            }
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            transaction.Rollback();
                        }
                    }
                    this.Close();
                }
            }
            
        }

        private void StreetTextBox1_Leave(object sender, EventArgs e)
        {
            string text = StreetTextBox1.Text;
            citiesDictionary.TryGetValue(CityTextBox1.Text, out var id_city);
            string[] strings = { StreetTextBox1.Text };
            int result = AddRecords.CorrectionCheck(
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
                if (text == StreetTextBox1.Text)
                {
                    StreetTextBox1.Text = "";
                    StreetTextBox1.Focus();
                }
                    
            }
        }

        private void CityTextBox1_Leave(object sender, EventArgs e)
        {
            string text = CityTextBox1.Text;
            countriesDictionary.TryGetValue(CounrtyComboBox1.Text, out var id_country);
            string[] strings = { CityTextBox1.Text };
            int result = AddRecords.CorrectionCheck(
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
                if (text == StreetTextBox1.Text)
                {
                    CityTextBox1.Text = "";
                    CityTextBox1.Focus();
                }
            }
        }

        private void ROVDTextBox_Leave(object sender, EventArgs e)
        {
            string text = ROVDTextBox.Text;
            string[] strings = { ROVDTextBox.Text };
            int result = AddRecords.CorrectionCheck(
                "SELECT COUNT(*) FROM ROVD" +
                " WHERE name=@value1",
                AddRecords.PutStringValuesIntoArray(strings)
                );
            if (result == 0)
            {
                ROVDCorrectionCheckForm rovdCorrection = new ROVDCorrectionCheckForm();

                rovdCorrection.notify = notify;
                rovdCorrection.ShowDialog(this);
                if (text == ROVDTextBox.Text)
                {
                    ROVDTextBox.Text = "";
                    ROVDTextBox.Focus();
                }
            }
        }

        private void MilitaryCommissariatTextBox_Leave(object sender, EventArgs e)
        {
            string text = "";
            string[] strings = { MilitaryCommissariatTextBox.Text };
            int result = AddRecords.CorrectionCheck(
                "SELECT COUNT(*) FROM Comissariat" +
                " WHERE name=@value1",
                AddRecords.PutStringValuesIntoArray(strings)
                );
            if (result == 0)
            {
                CommissariatCorrectionCheckForm commissariatCorrection = new CommissariatCorrectionCheckForm();

                commissariatCorrection.notify = notify;
                commissariatCorrection.ShowDialog(this);
                if (text == MilitaryCommissariatTextBox.Text)
                {
                    MilitaryCommissariatTextBox.Text = "";
                    MilitaryCommissariatTextBox.Focus();
                }
            }
        }

        private void CityTextBox2_Leave(object sender, EventArgs e)
        {
            string text = "";
            countriesDictionary.TryGetValue(CounrtyComboBox2.Text, out var id_country);
            string[] strings = { CityTextBox2.Text };
            int result = AddRecords.CorrectionCheck(
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
                if (text == CityTextBox2.Text)
                {
                    CityTextBox2.Text = "";
                    CityTextBox2.Focus();
                }
            }
        }

        private void StreetTextBox2_Leave(object sender, EventArgs e)
        {
            string text = "";
            citiesDictionary.TryGetValue(CityTextBox2.Text, out var id_city);
            string[] strings = { StreetTextBox2.Text };
            int result = AddRecords.CorrectionCheck(
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
                if (text == StreetTextBox2.Text)
                {
                    StreetTextBox2.Text = "";
                    StreetTextBox2.Focus();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string line = "";
                List<string> cells = new List<string>();

                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            cells.Add(cell.Value.ToString());
                        }
                    }
                    line = string.Join("", cells);
                    MessageBox.Show(line);
                }
            }
        }

        private void SerialTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void IdentityNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void IndexTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' ||
               !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void IdentityNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            IdentityNumberTextBox.Text = IdentityNumberTextBox.Text.ToUpper();
            IdentityNumberTextBox.SelectionStart = IdentityNumberTextBox.Text.Length; // Устанавливаем курсор в конец
        }

        private void NumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' ||
               !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
