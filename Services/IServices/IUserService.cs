using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IUserService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(string id, string token);
        Task<T> CreateAsync<T>(ApplicationUserDTO dto, string token);
        Task<T> UpdateAsync<T>(ApplicationUserDTO dto, string token);
        Task<T> DeleteAsync<T>(string id, string token);
    }
}
