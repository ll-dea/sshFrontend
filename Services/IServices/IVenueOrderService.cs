using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IVenueOrderService: IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VenueOrderDTO dto);
        Task<T> UpdateAsync<T>(VenueOrderDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
