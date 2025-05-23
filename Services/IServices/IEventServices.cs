using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IEventServices
    {
        Task<T> CreateAsync<T>(EventDTO dto, string token);
        Task<T> DeleteAsync<T>(int id);
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> UpdateAsync<T>(EventDTO dto);

       
    }
}
