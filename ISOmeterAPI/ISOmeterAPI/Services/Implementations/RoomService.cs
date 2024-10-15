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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly ISOmeterContext _context;
        public RoomService(IUserService userService, IHttpContextAccessor httpContextAccessor, ISOmeterContext context)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public bool AddRoom(AddRoomDTO addRoomDTO)
        {
            // Obtener el UserId desde las claims del JWT
            var userId = _userService.GetUserIdFromToken();

            var existingRoom = _context.Rooms
                .FirstOrDefault(r => r.Name == addRoomDTO.Name);

            if (existingRoom == null)
            {
                Room newRoom = new Room
                {
                    Name = addRoomDTO.Name,
                    Description = addRoomDTO.Description,
                    UserId = userId,  // Asignar el UserId obtenido desde las claims
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
            var userId = _userService.GetUserIdFromToken();

            return await _context.Rooms
                .Where(x => x.Status == true)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
    }
}
