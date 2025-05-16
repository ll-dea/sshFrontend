using SSH_FrontEnd.Models;
namespace SSH_FrontEnd.Models

{
    public class Table
    {
        public int TableId { get; set; }
        public int NumberOfSeats { get; set; }
        public int? TableStatusId { get; set; }
        public int? EventId { get; set; }
        public virtual Event Event { get; set; }
        public virtual ICollection<Guest> Guests { get; set; } = new List<Guest>();

 
    }
}
