using MagicVilla_Web.Services;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using Utility;

namespace SSH_FrontEnd.Services
{
    public class UserService : BaseServices, IUserService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _url;

        public UserService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            _url = configuration["ServicesUrls:EventPlannerAPI"] + "api/users";
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = _url,
                Token = token
            });
        }

        public Task<T> GetAsync<T>(string id, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = $"{_url}/{id}",
                Token = token
            });
        }

        public Task<T> CreateAsync<T>(ApplicationUserDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.POST,
                Url = _url,
                Data = dto,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(ApplicationUserDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.PUT,
                Url = $"{_url}/{dto.Id}",
                Data = dto,
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(string id, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.DELETE,
                Url = $"{_url}/{id}",
                Token = token
            });
        }

        public Task<List<ApplicationUserDTO>> GetAllAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDTO> GetAsync(string id, string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(ApplicationUserDTO userDto, string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ApplicationUserDTO userDto, string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id, string token)
        {
            throw new NotImplementedException();
        }
    }
}
