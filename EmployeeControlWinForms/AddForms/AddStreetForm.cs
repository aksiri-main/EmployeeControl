using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeControlWinForms.AddForms
{
    public partial class AddStreetForm : Form
    {
        public int id;
        public NotifyIcon notify;
        Dictionary<String, int> countriesDictionary = new Dictionary<String, int>();
        Dictionary<String, int> areasDictionary = new Dictionary<String, int>();
        Dictionary<String, int> citiesDictionary = new Dictionary<String, int>();
        public AddStreetForm()
        {
            InitializeComponent();
            AddRecords.FillComboBox("SELECT name, Id FROM Countries", CountriesComboBox, countriesDictionary);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string uniquenessQuery;
            citiesDictionary.TryGetValue(CitiesComboBox.Text, out int id_city);
            string[] strings = { id_city.ToString(), NameTextBox.Text };
            string query;

            if (AddButton.Text != "Изменить")
            {
                query = "INSERT INTO [Streets] (Id_City, name) VALUES (@value1, @value2)";
                uniquenessQuery = "SELECT COUNT(*) FROM Streets WHERE (Id_City = @value1 AND name = @value2)";
            }
            else
            {
                query = "UPDATE Streets SET Id_City=@value1, name=@value2 WHERE Id=@id";
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

                string[] values = { id_city.ToString(), NameTextBox.Text };

                AddRecords.AddRecordsMethod(
                    query,
                    AddRecords.PutStringValuesIntoArray(values),
                    AddButton.Text,
                    notify,
                    id
                    );

                this.Close();
            }
        }

        private void CountriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            countriesDictionary.TryGetValue(CountriesComboBox.Text, out int id_country);
            AddRecords.FillComboBox($"SELECT name, Id FROM Area WHERE Id_Country = {id_country}", AreasComboBox, areasDictionary);
        }

        private void AreasComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            areasDictionary.TryGetValue(AreasComboBox.Text, out int id_area);
            AddRecords.FillComboBox($"SELECT name, Id FROM Cities WHERE Id_Areas = {id_area}", CitiesComboBox, citiesDictionary);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CitiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
