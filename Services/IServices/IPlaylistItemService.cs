using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IPlaylistItemService: IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(PlaylistItemDTO dto);
        Task<T> UpdateAsync<T>(PlaylistItemDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
