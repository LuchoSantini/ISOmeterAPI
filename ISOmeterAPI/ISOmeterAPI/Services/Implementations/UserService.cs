using ISOmeterAPI.Context;
using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.UserDTOs;
using ISOmeterAPI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace ISOmeterAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISOmeterContext _context;
        public UserService(IHttpContextAccessor httpContextAccessor, ISOmeterContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public bool CreateUser(UserDTO userDTO)
        {
            if (ValidateEmail(userDTO.Email))
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);

                var newUser = new User()
                {
                    Name = userDTO.Name,
                    Surname = userDTO.Surname,
                    Email = userDTO.Email,
                    Password = hashedPassword,
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ValidateEmail(string email)
        {
            bool existingEmail = _context.Users.Any(u => u.Email == email);

            if (!existingEmail)
            {
                return true;
            }
            return false;
        }

        public bool ValidateUser(string Name)
        {
            bool existingName = _context.Users.Any(u => u.Name == Name);

            if (existingName == false)
            {
                return true;
            }
            return false;
        }

        public bool UserLogin(UserLoginDTO userLoginDTO)
        {
            User? userForLogin = _context.Users.SingleOrDefault(u => u.Email == userLoginDTO.Email);

            if (userForLogin != null)
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(userLoginDTO.Password, userForLogin.Password);

                if (isPasswordValid)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        public List<GetUsersDTO> GetAllUsers()
        {
            return _context.Users
                .Select(user => new GetUsersDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    UserType = user.UserType,
                })
                .ToList();
        }

        public bool DeleteUser(int id)
        {
            var existingUser = _context.Users.FirstOrDefault(x => x.Id == id && x.Status == true);
            if (existingUser != null)
            {
                existingUser.Status = false;
                _context.Users.Update(existingUser);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        //public GetUsersDTO GetUserByEmail(string email)
        //{
        //    var user = _context.Users.SingleOrDefault(e => e.Email == email);

        //    if (user == null) return null;

        //    return new GetUsersDTO
        //    {
        //        Id = user.Id,
        //        Name = user.Name,
        //        Surname = user.Surname,
        //        Email = user.Email,
        //        UserType = user.UserType,
        //    };
        //}

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(e => e.Email == email);
        }

        public int GetUserIdFromToken()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var authorizationHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();

                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);

                if (jwtToken != null && jwtToken.Claims.FirstOrDefault(c => c.Type == "sub") != null)
                {
                    var userId = int.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == "sub").Value);
                    return userId;
                }
            }

            throw new Exception("Error retrieving userId from token.");
        }
    }
}
