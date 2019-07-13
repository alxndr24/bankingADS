﻿namespace Banking.Application.Users.Dtos
{
    public class NewUserDto
    {
        public int Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Document { get; set; }
        public bool Active { get; set; }

        public NewUserDto()
        {
            Active = true;
        }
    }
}
