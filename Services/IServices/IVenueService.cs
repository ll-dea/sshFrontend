using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
namespace SSH_FrontEnd.Services.IServices
{
    public interface IVenueService : IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VenueDTO dto);
        Task<T> UpdateAsync<T>(VenueDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
