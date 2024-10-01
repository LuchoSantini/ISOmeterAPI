using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.UserDTOs;

namespace ISOmeterAPI.Services.Interfaces
{
    public interface IUserService
    {
        public bool CreateUser(UserDTO userDTO);
        public bool ValidateEmail(string email);
        public bool ValidateUser(string Name);
        public bool UserLogin(UserLoginDTO userLoginDTO);
        public bool DeleteUser(int id);
        public GetUsersDTO GetUserByEmail(string email);
        public List<GetUsersDTO> GetAllUsers();
    }
}
