using ISOmeterAPI.Data.Models.MeasurementDTOs;

namespace ISOmeterAPI.Data.Models.EssayDTOs
{
    public class GetEssayDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UniversalId { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomId { get; set; }
        public List<GetMeasurementByIdDTO> Measurements { get; set; } = new List<GetMeasurementByIdDTO>();
    }
}
