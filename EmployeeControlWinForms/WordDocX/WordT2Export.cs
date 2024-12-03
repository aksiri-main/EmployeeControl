using EmployeeControlWinForms.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace EmployeeControlWinForms.AddForms.WordDocX
{
    internal class WordT2Export
    {
        internal static void WordExport(int id)
        {
            string queryTable = "SELECT Id, kinship AS [Степень родства]," +
                                " CONCAT(surname, ' ', name, ' ', lastName, ' ') AS [ФИО]," +
                                " dateOfBirthday AS [Дата рождения] FROM Reliatives" +
                               $" WHERE Id_Employee = {id}";
            int day = Convert.ToDateTime(AddRecords.FillText($"SELECT fromDate FROM Passport WHERE id = {id}")).Day;
            int month = Convert.ToDateTime(AddRecords.FillText($"SELECT fromDate FROM Passport WHERE id = {id}")).Month;
            int year = Convert.ToDateTime(AddRecords.FillText($"SELECT fromDate FROM Passport WHERE id = {id}")).Year;
            string militaryAccounting1;
            string militaryAccounting2;

            

            if (AddRecords.FillTextBool($"SELECT militaryAccountingBool FROM MilitaryRegistration WHERE id = {id}"))
            {
                militaryAccounting1 = "<special>";
                militaryAccounting2 = "<general>";
            }
            else
            {
                militaryAccounting2 = "<special>";
                militaryAccounting1 = "<general>";
            }
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Word Pages|*.docx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Путь к исходному документу
                    string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WordDocX\\T2.docx");
                    // Путь для сохранения измененного документа
                    string outputFilePath = sfd.FileName;

                    // Словарь для замены ключевых слов
                    var replacements = new Dictionary<string, string>
                    {
                        { "<surname>", AddRecords.FillText($"SELECT surname FROM Employees WHERE id = {id}") },
                        { "<name>", AddRecords.FillText($"SELECT name FROM Employees WHERE id = {id}") },
                        { "<lastName>", AddRecords.FillText($"SELECT lastName FROM Employees WHERE id = {id}") },
                        { "<dateOfBirthday>", AddRecords.FillText($"SELECT dateOfBirthday FROM Employees WHERE id = {id}") },
                        { "<country1>", AddRecords.FillText($"SELECT Countries.name FROM RegistrationAddress" +
                        $" JOIN Countries ON RegistrationAddress.Id_Country = Countries.Id WHERE RegistrationAddress.id = {id}") },
                        { "<area1>", AddRecords.FillText($"SELECT Area.name FROM RegistrationAddress" +
                        $" JOIN Cities ON RegistrationAddress.Id_City = Cities.Id" +
                        $" JOIN Area ON Cities.Id_Areas = Area.Id WHERE RegistrationAddress.id = {id}") },
                        { "<city1>",  AddRecords.FillText($"SELECT Cities.name FROM RegistrationAddress" +
                        $" JOIN Cities ON RegistrationAddress.Id_City = Cities.Id WHERE RegistrationAddress.id = {id}") },
                        { "<serial>",  AddRecords.FillText($"SELECT serial FROM Passport WHERE id = {id}") },
                        { "<number>", AddRecords.FillText($"SELECT number FROM Passport WHERE id = {id}") },
                        { "<day>",  day.ToString() },
                        { "<month>", month.ToString() },
                        { "<year>", year.ToString() },
                        { "<rovd>", AddRecords.FillText($"SELECT ROVD.name FROM Passport" + 
                        $" JOIN ROVD ON Passport.Id_ROVD = ROVD.Id WHERE Passport.id = {id}") },
                        { "<index1>", AddRecords.FillText($"SELECT mailIndex FROM RegistrationAddress WHERE id = {id}") },
                        { "<street1>", AddRecords.FillText($"SELECT Streets.name FROM RegistrationAddress" +
                        $" JOIN Streets ON RegistrationAddress.Id_Street = Streets.Id WHERE RegistrationAddress.id = {id}") },
                        { "<house1>", AddRecords.FillText($"SELECT house FROM RegistrationAddress WHERE id = {id}") },
                        { "<apartament1>", AddRecords.FillText($"SELECT apartament FROM RegistrationAddress WHERE id = {id}") },
                        { "<index2>", AddRecords.FillText($"SELECT mailIndex FROM PlaceOfResidence WHERE id = {id}") },
                        { "<area2>", AddRecords.FillText($"SELECT Area.name FROM PlaceOfResidence" +
                        $" JOIN Cities ON PlaceOfResidence.Id_City = Cities.Id" +
                        $" JOIN Area ON Cities.Id_Areas = Area.Id WHERE PlaceOfResidence.id = {id}") },
                        { "<street2>", AddRecords.FillText($"SELECT Streets.name FROM PlaceOfResidence" +
                        $" JOIN Streets ON PlaceOfResidence.Id_Street = Streets.Id WHERE PlaceOfResidence.id = {id}") },
                        { "<house2>", AddRecords.FillText($"SELECT house FROM PlaceOfResidence WHERE id = {id}") },
                        { "<apartament2>", AddRecords.FillText($"SELECT apartament FROM PlaceOfResidence WHERE id = {id}") },
                        { "<phoneNumber>", AddRecords.FillText($"SELECT phoneNumber FROM RegistrationAddress WHERE id = {id}") },
                        { "<stockCategory>", AddRecords.FillText($"SELECT stockCategory FROM MilitaryRegistration WHERE id = {id}") },
                        { "<militaryRank>", AddRecords.FillText($"SELECT militaryRank FROM MilitaryRegistration WHERE id = {id}") },
                        { "<сomposition>" , AddRecords.FillText($"SELECT сomposition FROM MilitaryRegistration WHERE id = {id}") },
                        { "<codeVUS>", AddRecords.FillText($"SELECT codeVUS FROM MilitaryRegistration WHERE id = {id}") },
                        { "<suitabilityCategory>", AddRecords.FillText($"SELECT suitabilityCategory FROM MilitaryRegistration WHERE id = {id}") },
                        { "<Comissariat>", AddRecords.FillText($"SELECT Comissariat.name FROM MilitaryRegistration" +
                        $" JOIN Comissariat ON MilitaryRegistration.ID_Comissariat = Comissariat.id WHERE MilitaryRegistration.id = {id}") },
                        { militaryAccounting1, AddRecords.FillText($"SELECT militaryAccounting FROM MilitaryRegistration WHERE id = {id}") },
                        { militaryAccounting2, "" },
                        { "<markAccounting>", AddRecords.FillText($"SELECT markAccounting FROM MilitaryRegistration WHERE id = {id}") }

                    };

                    // Открываем документ
                    using (var document = DocX.Load(inputFilePath))
                    {
                        var table = document.Tables[7];

                        using (SqlConnection connection = new SqlConnection(DatabaseSettings.connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(queryTable, connection))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int rowIndex = 2; // Индекс, начиная со строки после заголовка
                                    while (reader.Read())
                                    {
                                        // Проверяем, чтобы не выходить за пределы таблицы
                                        if (rowIndex >= table.RowCount)
                                        {
                                            // Если строка не существует, добавляем новую
                                            table.InsertRow(rowIndex);
                                        }

                                        var column1Value = reader["Степень родства"].ToString();
                                        var column2Value = reader["ФИО"].ToString();
                                        var column3Value = reader["Дата рождения"].ToString();

                                        // Заполняем ячейки
                                        table.Rows[rowIndex].Cells[0].Paragraphs[0].Append(column1Value);
                                        table.Rows[rowIndex].Cells[1].Paragraphs[0].Append(column2Value);
                                        table.Rows[rowIndex].Cells[2].Paragraphs[0].Append(column3Value);

                                        rowIndex++;
                                    }

                                    // Если прочитаны все данные, можно удалить лишние строки в таблице, если необходимо
                                    while (rowIndex < table.RowCount)
                                    {
                                        table.RemoveRow(rowIndex);
                                    }
                                }
                            }
                        }

                        // Заменяем ключевые слова
                        foreach (var replacement in replacements)
                        {
                            document.ReplaceText(replacement.Key, replacement.Value);
                        }

                        // Сохраняем изменения
                        document.SaveAs(outputFilePath);
                    }

                    Console.WriteLine("Замены выполнены успешно!");
                }
            }
        }
    }
}
