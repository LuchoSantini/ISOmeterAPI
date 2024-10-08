using OfficeOpenXml;
using Microsoft.Data.Sqlite;
using System.Data;
using ISOmeterAPI.Services.Interfaces;

namespace ISOmeterAPI.Services.Implementations
{
    public class ExportDBService : IExportDBService
    {
        private readonly string _connectionString;

        public ExportDBService(string connectionString)
        {
            _connectionString = connectionString;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        public void ExportDatabaseToExcel(string outputPath)
        {
            try
            {
                // Verificar que el directorio existe
                string directory = Path.GetDirectoryName(outputPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                List<string> tableNames = GetTableNames();

                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    foreach (string tableName in tableNames)
                    {
                        DataTable table = GetDataFromTable(tableName);
                        AddDataTableToExcel(excelPackage, table, tableName);
                    }

                    FileInfo excelFile = new FileInfo(outputPath);
                    excelPackage.SaveAs(excelFile);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al exportar la base de datos: {ex.Message}");
                // Manejo adicional del error si es necesario
            }
        }

        public List<string> GetTableNames()
        {
            List<string> tableNames = new List<string>();
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tableNames.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return tableNames;
        }

        public DataTable GetDataFromTable(string tableName)
        {
            DataTable dataTable = new DataTable();
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName}";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }

        public void AddDataTableToExcel(ExcelPackage excelPackage, DataTable dataTable, string sheetName)
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(sheetName);
            worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);
        }
    }
}
