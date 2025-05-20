using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IPastryTypeService: IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(PastryTypeDTO dto);
        Task<T> UpdateAsync<T>(PastryTypeDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
