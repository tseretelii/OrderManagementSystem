﻿namespace OrderManagementSystem.Data.DTOS.User
{
    public class UserCreationDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}
