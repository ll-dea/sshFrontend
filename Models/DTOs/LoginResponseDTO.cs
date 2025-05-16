namespace SSH_FrontEnd.Models.DTOs
{
    public class LoginResponseDTO
    {
        public ApplicationUserDTO User { get; set; }
        public string Token { get; set; }
    }
}

