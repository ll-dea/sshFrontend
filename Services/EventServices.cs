using MagicVilla_Web.Services;
using Microsoft.Extensions.Configuration;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using Utility;

namespace SSH_FrontEnd.Services
{
    public class EventServices: BaseServices, IEventServices

    {
        private readonly IHttpClientFactory _clientFactory;
        private string eventUrl;
        
        public EventServices(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            eventUrl = configuration.GetValue<string>("ServicesUrls:EventPlannerAPI");
        }

        public Task<T> CreateAsync<T>(EventDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = eventUrl + "api/Event"
                
            });
        }
        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = eventUrl + "api/Event/" + id
            });
        }
        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = eventUrl + "api/Event"
            });
        }
        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = eventUrl + "api/Event/" + id
            });
        }
        public Task<T> UpdateAsync<T>(EventDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = eventUrl + "api/EventAPI/" + dto.EventId
            });
        }

    }
}
