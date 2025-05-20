using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IOrderStatusService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(OrderStatusDTO dto);
        Task<T> UpdateAsync<T>(OrderStatusDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
