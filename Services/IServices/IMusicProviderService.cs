using SSH_FrontEnd.Models;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IMusicProviderService : IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(MusicProvider dto);
        Task<T> UpdateAsync<T>(MusicProvider dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
