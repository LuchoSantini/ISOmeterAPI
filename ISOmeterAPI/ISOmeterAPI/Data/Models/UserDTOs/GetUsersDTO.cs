namespace ISOmeterAPI.Data.Models.UserDTOs
{
    public class GetUsersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
    }
}
