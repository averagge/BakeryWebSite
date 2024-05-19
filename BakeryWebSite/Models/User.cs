namespace BakeryWebSite.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public User() { }
        public User(string login, string password, string email, string role, string phone, string name, string surname, string address)
        {
            Login = login;
            Password = password;
            Email = email;
            Role = role;
            Phone = phone;
            Name = name;
            Surname = surname;
            Address = address;
        }
    }
}
