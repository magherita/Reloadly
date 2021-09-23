using Domain.Location;

namespace Application.Models.Users
{
    public class UpdateUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Email { get; set; }
        public string  PhoneNumber { get; set; }
        public string UserName { get; set; }
        public  Location Location{ get; set; }
    }
}