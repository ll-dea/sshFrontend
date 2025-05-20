using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IPastryShopService: IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(PastryShopDTO dto);
        Task<T> UpdateAsync<T>(PastryShopDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
