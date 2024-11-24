using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControlWinForms.DB
{
    internal static class DatabaseSettings
    {
        internal static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; " +
                                  "AttachDbFileName=|DataDirectory|\\DB\\Database2.mdf; " +
                                  "Integrated Security=True;";

        internal static string employeeTable = "SELECT Id, surname AS [Фамилия], name AS [Имя], lastName AS [Отчество] FROM Employees";

        internal static string reliativesTable = "SELECT Id, kinship AS [Степень родства]," +
                                                 " CONCAT(surname, ' ', name, ' ', lastName) AS [ФИО]," +
                                                 " dateOfBirthday AS [Дата рождения] FROM Reliatives";

        internal static string countriesTable = "SELECT Id, name AS [Наименование] FROM Countries";
    }
}
