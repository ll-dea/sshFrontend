using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IVenueProviderService:IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VenueProviderDTO dto);
        Task<T> UpdateAsync<T>(VenueProviderDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
