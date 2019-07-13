namespace Banking.Application.Auth.Dtos
{
    public class LoginDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public LoginDto()
        {          
        }
    }
}
