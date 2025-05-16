using MagicVilla_Web.Services;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Services.IServices;
using Utility;

namespace SSH_FrontEnd.Services
{
    public class VenueService : BaseServices, IVenueService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _venueUrl;

        public VenueService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            _venueUrl = configuration.GetValue<string>("ServicesUrls:EventPlannerAPI") + "/api/Venue";
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _venueUrl
            });
        }
    }
}
