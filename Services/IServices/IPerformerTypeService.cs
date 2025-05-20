using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IPerformerTypeService :IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(PerformerTypeDTO dto);
        Task<T> UpdateAsync<T>(PerformerTypeDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
