using MagicVilla_Web.Services;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Services.IServices;
using Utility;

namespace SSH_FrontEnd.Services
{
    public class FloristService : BaseServices, IFloristService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _floristUrl;

        public FloristService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            _floristUrl = configuration.GetValue<string>("ServicesUrls:EventPlannerAPI") + "/api/Florist";
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _floristUrl
            });
        }
    }
}
