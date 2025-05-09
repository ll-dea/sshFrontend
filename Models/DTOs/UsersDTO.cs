﻿namespace sshBackend1.Models.DTOs
{
    public class UsersDTO
    {
        public string Id { get; set; }

        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ProfilePictureUrl { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
    }
}
