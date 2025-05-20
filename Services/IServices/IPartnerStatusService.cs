using SSH_FrontEnd.Models.DTOs;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IPartnerStatusService: IBaseServices
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(PartnerStatusDTO dto);
        Task<T> UpdateAsync<T>(PartnerStatusDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
