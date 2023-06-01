using maneroSub.Models.Interfaces.UserProfile;

namespace maneroSub.Models.Dtos
{
    public class User : IUser
    {
        Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public int PhoneNumber { get; set; }

        public string Adress { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

    }
}
