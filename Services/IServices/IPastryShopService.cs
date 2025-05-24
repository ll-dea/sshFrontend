using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IPastryShopService : IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(PastryShopDTO dto, string token);
        Task<T> UpdateAsync<T>(PastryShopDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
