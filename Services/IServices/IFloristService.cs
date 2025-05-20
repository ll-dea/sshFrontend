using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IFloristService : IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(FloristDTO dto);
        Task<T> UpdateAsync<T>(FloristDTO dto);
        Task<T> DeleteAsync<T>(int id);

    }
}
