using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.EssayDTOs;
using ISOmeterAPI.Data.Models.RoomDTO;

namespace ISOmeterAPI.Services.Interfaces
{
    public interface IEssayService
    {
        public Task<bool> AddEssayAsync(int universalId);
        public Task<IEnumerable<GetEssayDTO>> GetEssayById(int deviceId, int roomId);
    }
}
