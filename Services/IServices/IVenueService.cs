using SSH_FrontEnd.Models;
using SSH_FrontEnd.Services.IServices;
namespace SSH_FrontEnd.Services.IServices
{
    public interface IVenueService : IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(Venue dto);
        Task<T> UpdateAsync<T>(Venue dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
