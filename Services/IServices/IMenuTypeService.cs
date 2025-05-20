using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IMenuTypeService : IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(MenuTypeDTO dto);
        Task<T> UpdateAsync<T>(MenuTypeDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
