namespace maneroSub.Models.Interfaces.UserProfile
{
    public interface IUser
    {
        string Adress { get; set; }
        string City { get; set; }
        string ConfirmPassword { get; set; }
        string Email { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        int PhoneNumber { get; set; }
        string PostalCode { get; set; }
    }
}