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

        internal static string countriesTable = "SELECT Id, name AS [Страна] FROM Countries";

        internal static string areasTable = "SELECT Area.Id, Id_Country, Countries.name AS [Страна], Area.name AS [Область] FROM Area" +
                                            " JOIN Countries ON Area.Id_Country = Countries.Id";

        internal static string citiesTable = "SELECT Id, Countries.name AS [Страна]," +
                                             " name AS [Город]" +
                                             " FROM Cities" +
                                             " JOIN Countries ON Cities.Id_Country = Countries.Id";
    }
}
