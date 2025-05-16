using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.VM.Client
{
    public class ProfileViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }

}
