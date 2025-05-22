using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IPastryOrderService : IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(PastryOrderDTO dto);
        Task<T> UpdateAsync<T>(PastryOrderDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
