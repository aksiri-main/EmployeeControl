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

        internal static string citiesTable = "SELECT Cities.Id, Id_Areas, Countries.name AS [Страна]," +
                                             " Area.name AS [Область]," +
                                             " Cities.name AS [Город]" +
                                             " FROM Cities" +
                                             " JOIN Area ON Cities.Id_Areas = Area.Id" +
                                             " JOIN Countries ON Area.Id_Country = Countries.Id";

        internal static string streetsTable = "SELECT Streets.Id, Id_City, Countries.name AS [Страна]," +
                                             " Area.name AS [Область]," +
                                             " Cities.name AS [Город]," +
                                             " Streets.name AS [Улица]" +
                                             " FROM Streets" +
                                             " JOIN Cities ON Streets.Id_City = Cities.Id" +
                                             " JOIN Area ON Cities.Id_Areas = Area.Id" +
                                             " JOIN Countries ON Area.Id_Country = Countries.Id";

        internal static string rovdTable = "SELECT ROVD.Id, Id_City, Countries.name AS [Страна]," +
                                             " Area.name AS [Область]," +
                                             " Cities.name AS [Город]," +
                                             " ROVD.name AS [РОВД]" +
                                             " FROM ROVD" +
                                             " JOIN Cities ON ROVD.Id_City = Cities.Id" +
                                             " JOIN Area ON Cities.Id_Areas = Area.Id" +
                                             " JOIN Countries ON Area.Id_Country = Countries.Id";

        internal static string commissariatsTable = "SELECT Comissariat.Id, Id_City, Countries.name AS [Страна]," +
                                             " Area.name AS [Область]," +
                                             " Cities.name AS [Город]," +
                                             " Comissariat.name AS [Комиссариат]" +
                                             " FROM Comissariat" +
                                             " JOIN Cities ON Comissariat.Id_City = Cities.Id" +
                                             " JOIN Area ON Cities.Id_Areas = Area.Id" +
                                             " JOIN Countries ON Area.Id_Country = Countries.Id";
    }
}
