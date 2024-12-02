using EmployeeControlWinForms.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeControlWinForms.AddForms
{
    internal static class AddRecords
    {
        internal static int CorrectionCheck(string query, Dictionary<string, string> keyValues)
        {
            SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            // Задание параметров
            foreach (var kVal in keyValues)
            {
                command.Parameters.AddWithValue(kVal.Key, kVal.Value);
            }
            int count = (int)command.ExecuteScalar();

            if (count > 0)
                return count;
            else 
                return 0;
        }


        //Проверка на уникальность записи
        internal static int UniquenessCheck(string query, Dictionary<string, string> keyValues)
        {
            SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            // Задание параметров
            foreach (var kVal in keyValues)
            {
                command.Parameters.AddWithValue(kVal.Key, kVal.Value);
            }

            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show("Данная запись уже существует!");
                return count;
            }
            else { return 0; }
        }

        internal static int ReturnIdRecordCheck(string query, Dictionary<string, string> keyValues)
        {
            SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            // Задание параметров
            foreach (var kVal in keyValues)
            {
                command.Parameters.AddWithValue(kVal.Key, kVal.Value);
            }

            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {
                return count;
            }
            else { return 0; }
        }

        //Преобразование массива строк в словарь
        internal static Dictionary<string, string> PutStringValuesIntoArray(string[] values)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            int number = 1;
            foreach (string value in values)
            {
                keyValuePairs.Add($"@value{number++}", value);
            }
            return keyValuePairs;
        }

        //Настройка всплывающего уведомления
        internal static void NotifyIconSettings(NotifyIcon notifyIcon,
                                       ToolTipIcon balloonIcon,
                                       string balloonTitle,
                                       string balloonText,
                                       int showBalloonTime)
        {
            notifyIcon.Icon = SystemIcons.WinLogo;
            notifyIcon.BalloonTipIcon = balloonIcon;
            notifyIcon.BalloonTipTitle = balloonTitle;
            notifyIcon.BalloonTipText = balloonText;
            // отображаем подсказку (кол-во секунд)
            notifyIcon.ShowBalloonTip(showBalloonTime);
        }

        internal static void FillDictionary(string query, Dictionary<string, int> keyValues)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string value = reader.GetString(0);
                    int id = reader.GetInt32(1);

                    keyValues.Add(value, id);
                }

                reader.Close();

            }
        }


        //Заполнение ComboBox
        internal static void FillComboBox(string query, ComboBox comboBox, Dictionary<string, int> keyValues)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string value = reader.GetString(0);
                    int id = reader.GetInt32(1);

                    comboBox.Items.Add(value);
                    keyValues.Add(value, id);
                }

                reader.Close();

            }
        }

        internal static string FillText(string query)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return reader.GetString(0);
                }

                reader.Close();
                
            }
            return null;
        }
        internal static bool FillTextBool(string query)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return reader.GetBoolean(0);
                }

                reader.Close();

            }
            return false;
        }
        internal static void FillComboBox(string query, ComboBox comboBox, Dictionary<string, int> keyValues, ComboBox comboBox2, Dictionary<string, int> keyValues2)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string value = reader.GetString(0);
                    int id = reader.GetInt32(1);
                    int id2 = reader.GetInt32(2);

                    comboBox.Items.Add(value);
                    keyValues.Add(value, id);
                    keyValues2.Add(value, id2);
                }

                reader.Close();

            }
        }

        //Добавление или изменение записей в таблице
        internal static void AddRecordsMethod(string query, Dictionary<string, string> keyValues, string buttonText, NotifyIcon notify, int id)
        {
            SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            // Задание параметров
            command.Parameters.AddWithValue("@id", id);
            foreach (var kVal in keyValues)
            {
                command.Parameters.AddWithValue(kVal.Key, kVal.Value);
            }

            command.ExecuteNonQuery();

            connection.Close();
            string balloonText;
            if (buttonText != "Изменить")
            {
                balloonText = "Запись добавлена!";
            }
            else
            {
                balloonText = "Запись изменена!";
            }

            NotifyIconSettings(notify, ToolTipIcon.Info, "Успешно!", balloonText, 3);
        }

        internal static void AddRecordsMethod(string query, Dictionary<string, string> keyValues, int id)
        {
            SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            // Задание параметров
            command.Parameters.AddWithValue("@id", id);
            foreach (var kVal in keyValues)
            {
                command.Parameters.AddWithValue(kVal.Key, kVal.Value);
            }

            command.ExecuteNonQuery();

            connection.Close();
        }

        internal static void AddRecordsMethod(string query, Dictionary<string, string> keyValues, int id, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand command = new SqlCommand(query, connection, transaction);

            // Задание параметров
            command.Parameters.AddWithValue("@id", id);
            foreach (var kVal in keyValues)
            {
                command.Parameters.AddWithValue(kVal.Key, kVal.Value);
            }

            command.ExecuteNonQuery();
        }

        internal static void DeleteDivisionsInUsersRoles(int id, string deleteCommandText)
        {
            // Создаем подключение и команду для удаления
            using (SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString))
            {
                using (SqlCommand deleteCommand = new SqlCommand(deleteCommandText, connection))
                {
                    // Добавляем параметр @KeyValue к команде удаления
                    deleteCommand.Parameters.AddWithValue("@KeyValue", id);

                    // Открываем соединение и выполняем команду удаления
                    connection.Open();
                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                }
            }
        }
        internal static void DeletingRecordsFromTheDataBase(int id, string deleteCommandText)
        {
            // Создаем подключение и команду для удаления
            using (SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString))
            {
                using (SqlCommand deleteCommand = new SqlCommand(deleteCommandText, connection))
                {
                    // Добавляем параметр @KeyValue к команде удаления
                    deleteCommand.Parameters.AddWithValue("@KeyValue", id);

                    // Открываем соединение и выполняем команду удаления
                    connection.Open();
                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                }
            }
        }
        //OVERLOAD
        internal static void DeletingRecordsFromTheDataBase(int id, string deleteCommandText, SqlConnection connection, SqlTransaction transaction)
        {
            // Создаем подключение и команду для удаления
            using (SqlCommand deleteCommand = new SqlCommand(deleteCommandText, connection, transaction))
            {
                // Добавляем параметр @KeyValue к команде удаления
                deleteCommand.Parameters.AddWithValue("@KeyValue", id);
                int rowsAffected = deleteCommand.ExecuteNonQuery();
            }
        }
    }
}

