using SSH_FrontEnd.Models;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IRestaurantService : IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(Restaurant dto);
        Task<T> UpdateAsync<T>(Restaurant dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
