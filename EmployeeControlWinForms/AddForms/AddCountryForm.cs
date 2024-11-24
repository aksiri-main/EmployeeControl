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
    public partial class AddCountryForm : Form
    {
        public int id;
        public NotifyIcon notify;
        public AddCountryForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string uniquenessQuery;
            string[] strings = { NameTextBox.Text };
            string query;

            if (AddButton.Text != "Изменить")
            {
                query = "INSERT INTO [Countries] (name) VALUES (@value1)";
                uniquenessQuery = "SELECT COUNT(*) FROM Countries WHERE name = @value1";
            }
            else
            {
                query = "UPDATE Countries SET name=@value1 WHERE Id=@id";
                uniquenessQuery = $"SELECT COUNT(*) FROM Countries WHERE name = @value1 AND id != '{id}'";
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

                string[] values = { NameTextBox.Text};

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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
