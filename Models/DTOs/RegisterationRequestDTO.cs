﻿namespace SSH_FrontEnd.Models.DTOs
{
    public class RegisterationRequestDTO
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "customer";
    }
}
