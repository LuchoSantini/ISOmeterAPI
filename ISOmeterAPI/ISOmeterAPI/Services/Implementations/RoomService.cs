using ISOmeterAPI.Context;
using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.DeviceDTOs;
using ISOmeterAPI.Data.Models.RoomDTO;
using ISOmeterAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ISOmeterAPI.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly ISOmeterContext _context;
        public RoomService(ISOmeterContext context)
        {
            _context = context;
        }

        public bool AddRoom(AddRoomDTO addRoomDTO)
        {
            var existingRoom = _context.Rooms
                .FirstOrDefault(r => r.Name == addRoomDTO.Name);

            var existingUser = _context.Users
                .FirstOrDefault(u => u.Id == addRoomDTO.UserId);

            if (existingRoom == null)
            {
                Room newRoom = new Room
                {
                    Name = addRoomDTO.Name,
                    Description = addRoomDTO.Description,
                    UserId = addRoomDTO.UserId,
                    Status = true
                };

                _context.Rooms.Add(newRoom);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _context.Rooms
                .Where(x => x.Status == true)
                .ToListAsync();
        }
    }
}
