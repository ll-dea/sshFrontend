using SSH_FrontEnd.Models;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IPastryService : IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(Pastry dto);
        Task<T> UpdateAsync<T>(Pastry dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
