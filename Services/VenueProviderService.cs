using MagicVilla_Web.Services;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using Utility;
namespace SSH_FrontEnd.Services { 
    public class VenueProviderService : BaseServices, IVenueProviderService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _url;

        public VenueProviderService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            _url = configuration["ServicesUrls:EventPlannerAPI"] + "api/VenueProvider";
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest { ApiType = SD.ApiType.GET, Url = _url });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest { ApiType = SD.ApiType.GET, Url = $"{_url}/{id}" });
        }

        public Task<T> CreateAsync<T>(VenueProviderDTO dto)
        {
            return SendAsync<T>(new APIRequest { ApiType = SD.ApiType.POST, Data = dto, Url = _url });
        }

        public Task<T> UpdateAsync<T>(VenueProviderDTO dto)
        {
            return SendAsync<T>(new APIRequest { ApiType = SD.ApiType.PUT, Data = dto, Url = $"{_url}/{dto.VenueProviderId}" });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest { ApiType = SD.ApiType.DELETE, Url = $"{_url}/{id}" });
        }

    }
}