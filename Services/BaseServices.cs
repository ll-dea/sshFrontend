using SSH_FrontEnd.Models;
using SSH_FrontEnd.Services.IServices;
using System.Text;
using Utility;
using Newtonsoft.Json;
using System.Net.Http;

namespace MagicVilla_Web.Services
{
    public class BaseServices : IBaseServices
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseServices(IHttpClientFactory httpClient)
        {
            this.responseModel = new();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("EventPlannerAPI");
                var message = new HttpRequestMessage
                {
                    RequestUri = new Uri(apiRequest.Url),
                    Headers = { { "Accept", "application/json" } },
                    Method = apiRequest.ApiType switch
                    {
                        SD.ApiType.POST => HttpMethod.Post,
                        SD.ApiType.PUT => HttpMethod.Put,
                        SD.ApiType.DELETE => HttpMethod.Delete,
                        _ => HttpMethod.Get
                    }
                };

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                                        Encoding.UTF8, "application/json");
                }

                var apiResponse = await client.SendAsync(message);
                var content = await apiResponse.Content.ReadAsStringAsync();

                if (!apiResponse.IsSuccessStatusCode)
                {
                    var error = new APIResponse
                    {
                        StatusCode = apiResponse.StatusCode,
                        IsSuccess = false,
                        ErrorsMessages = new List<string> { content }
                    };
                    return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(error));
                }

                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception e)
            {
                var dto = new APIResponse()
                {
                    ErrorsMessages = new List<string> { e.Message },
                    IsSuccess = false
                };
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(dto));
            }
        }



    }
}


