using Domain.Location;

namespace Application.Models.Wallets
{
    public class AddDonationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Email { get; set; }
        public string  PhoneNumber { get; set; }
        public string Password { get; set; }
        public  Location Location{ get; set; }
        public string Amount { get; set; }
    }
}