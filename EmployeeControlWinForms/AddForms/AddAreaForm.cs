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
        public AddAreaForm()
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
                query = "INSERT INTO [Areas] (Id, name) VALUES (@value1, @value2)";
                uniquenessQuery = "SELECT COUNT(*) FROM Areas WHERE name = @value1";
            }
            else
            {
                query = "UPDATE Areas SET name=@value1, name=@value1 WHERE Id=@id";
                uniquenessQuery = $"SELECT COUNT(*) FROM Areas WHERE name = @value1 AND id != '{id}'";
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
