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
    public partial class SimpleAddAreaForm : Form
    {
        public int id;
        public NotifyIcon notify;
        public SimpleAddAreaForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string uniquenessQuery;
            string[] strings = { id.ToString(), NameTextBox.Text };
            string query;

            if (AddButton.Text != "Изменить")
            {
                query = "INSERT INTO [Area] (Id_Country, name) VALUES (@value1, @value2)";
                uniquenessQuery = "SELECT COUNT(*) FROM Area WHERE (Id_Country = @value1 AND name = @value2)";
            }
            else
            {
                query = "UPDATE Area SET Id_Country=@value1, name=@value2 WHERE Id=@id";
                uniquenessQuery = $"SELECT COUNT(*) FROM Area WHERE (Id_Country = @value1 AND name = @value2) AND id != '{id}'";
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

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
