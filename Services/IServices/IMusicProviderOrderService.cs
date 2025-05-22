using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IMusicProviderOrderService : IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(MusicProviderOrderDTO dto);
        Task<T> UpdateAsync<T>(MusicProviderOrderDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
