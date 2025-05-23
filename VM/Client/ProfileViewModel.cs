using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.VM.Client
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? RegisteredDate { get; set; }
    }


}
