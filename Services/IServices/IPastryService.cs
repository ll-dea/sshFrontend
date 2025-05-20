using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IPastryService : IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(PastryDTO dto);
        Task<T> UpdateAsync<T>(PastryDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
