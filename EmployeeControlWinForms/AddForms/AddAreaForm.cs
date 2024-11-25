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
    public partial class AddAreaForm : Form
    {
        public int id;
        public NotifyIcon notify;
        Dictionary<String, int> countriesDictionary = new Dictionary<String, int>();
        public AddAreaForm()
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
            countriesDictionary.TryGetValue(CountriesComboBox.Text, out int id_county);
            string uniquenessQuery;
            string[] strings = { id_county.ToString(), NameTextBox.Text };
            string query;

            if (AddButton.Text != "Изменить")
            {
                query = "INSERT INTO [Area] (Id_Country, name) VALUES (@value1, @value2)";
                uniquenessQuery = "SELECT COUNT(*) FROM Area WHERE (Id_Country = @value1 AND name = @value2)";
            }
            else
            {
                query = "UPDATE Area SET Id_Country=@value1, name=@value2 WHERE Id=@id";
                uniquenessQuery = $"SELECT COUNT(*) FROM Are WHERE (Id_Country = @value1 AND name = @value2) AND id != '{id}'";
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

                string[] values = { NameTextBox.Text };

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
    }
}
