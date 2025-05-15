using SSH_FrontEnd.Models;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IBaseServices
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);

    }
}
