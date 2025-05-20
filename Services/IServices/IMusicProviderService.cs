using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IMusicProviderService : IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(MusicProviderDTO dto);
        Task<T> UpdateAsync<T>(MusicProviderDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
