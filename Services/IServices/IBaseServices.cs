using SSH_FrontEnd.Models;

namespace SSH_FrontEnd.Services.IServices
{
    public interface IBaseServices
    {
        Task<T> SendAsync<T>(APIRequest apiRequest);

    }
}
