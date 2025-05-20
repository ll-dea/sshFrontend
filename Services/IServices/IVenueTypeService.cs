using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IVenueTypeService:IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VenueTypeDTO dto);
        Task<T> UpdateAsync<T>(VenueTypeDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
