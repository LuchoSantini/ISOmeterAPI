using System.Text.Json.Serialization;

namespace ISOmeterAPI.Data.Models.ExportDBDTOs
{
    public class PathDTO
    {
        [JsonIgnore]
        public string OutputPath { get; set; } = "C:\\Users\\desar\\OneDrive\\Escritorio\\ISOmeterDB.xlsx";
    }
}
