using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IUserService : IBaseServices
    {
        //Task<UsersDTO> AuthenticateAsync(string username, string password);
        //Task RegisterAsync(RegisterDto registerDto);
        //Task<UsersDTO> GetUserByIdAsync(int id);
        //Task<IEnumerable<BookingDto>> GetUserBookingsAsync(int userId);
        Task<IEnumerable<EventDTO>> GetUserEventsAsync(int userId);
    }
}
