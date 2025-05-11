using SSH_FrontEnd.Models;
using SSH_FrontEnd.Services.IServices;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using Utility;

namespace SSH_FrontEnd.Services
{
    public class BaseServices : IBaseServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public APIResponse ResponseModel { get; set; }

        public BaseServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            ResponseModel = new APIResponse();
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("SSHAPI");
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                var apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiContent);
            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessages = new List<string> { ex.Message },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                return JsonConvert.DeserializeObject<T>(res);
            }
        }
    }
}