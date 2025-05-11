using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using Utility;

namespace SSH_FrontEnd.Services
{
    public class UserService : BaseServices, IUserService
    {
        public UserService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }

        public async Task<IEnumerable<EventDTO>> GetUserEventsAsync(int userId)
        {
            var request = new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = $"https://localhost:5221/api/users/{userId}/events"
            };

            return await SendAsync<IEnumerable<EventDTO>>(request);
        }
    }
}
