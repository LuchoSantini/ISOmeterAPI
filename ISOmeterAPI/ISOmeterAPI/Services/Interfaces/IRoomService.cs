using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.RoomDTO;

namespace ISOmeterAPI.Services.Interfaces
{
    public interface IRoomService
    {
        public bool AddRoom(AddRoomDTO addRoomDTO);
        public Task<IEnumerable<Room>> GetAllRooms();
    }
}
