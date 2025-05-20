using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IMenuOrderService : IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(MenuOrderDTO dto);
        Task<T> UpdateAsync<T>(MenuOrderDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
