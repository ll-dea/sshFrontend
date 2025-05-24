using MagicVilla_Web.Services;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using Utility;

namespace SSH_FrontEnd.Services
{
    public class MusicProviderService : BaseServices, IMusicProviderService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _url;

        public MusicProviderService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            _url = configuration["ServicesUrls:EventPlannerAPI"] + "api/MusicProvider";
        }

        public async Task<T> GetAllAsync<T>()
        {
            return await SendAsync<T>(new APIRequest { ApiType = SD.ApiType.GET, Url = _url });
        }

        public async Task<T> GetAsync<T>(int id)
        {
            return await SendAsync<T>(new APIRequest { ApiType = SD.ApiType.GET, Url = $"{_url}/{id}" });
        }

        public async Task<T> CreateAsync<T>(MusicProviderDTO dto)
        {
            return await SendAsync<T>(new APIRequest { ApiType = SD.ApiType.POST, Data = dto, Url = _url });
        }

        public async Task<T> UpdateAsync<T>(MusicProviderDTO dto)
        {
            return await SendAsync<T>(new APIRequest { ApiType = SD.ApiType.PUT, Data = dto, Url = $"{_url}/{dto.MusicProviderId}" });
        }

        public async Task<T> DeleteAsync<T>(int id)
        {
            return await SendAsync<T>(new APIRequest { ApiType = SD.ApiType.DELETE, Url = $"{_url}/{id}" });
        }
    }
}
