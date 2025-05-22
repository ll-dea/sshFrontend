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

                // Always deserialize as APIResponse first
                var deserializedResponse = JsonConvert.DeserializeObject<APIResponse>(content);

                if (!apiResponse.IsSuccessStatusCode || deserializedResponse == null || !deserializedResponse.IsSuccess)
                {
                    deserializedResponse ??= new APIResponse();
                    deserializedResponse.IsSuccess = false;
                    deserializedResponse.StatusCode = apiResponse.StatusCode;
                    deserializedResponse.ErrorsMessages ??= new List<string> { content };
                    return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(deserializedResponse));
                }

                // Extract the actual result
                if (typeof(T) == typeof(APIResponse))
                {
                    return JsonConvert.DeserializeObject<T>(content); // Return raw APIResponse
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(deserializedResponse.Result)); // Return just Result
                }
            }
            catch (Exception ex)
            {
                var errorResponse = new APIResponse
                {
                    IsSuccess = false,
                    ErrorsMessages = new List<string> { ex.Message }
                };
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(errorResponse));
            }
        }


        public virtual Task<T> GetAllAsync<T>()
        {
            throw new NotImplementedException("GetAllAsync must be implemented in derived services.");
        }


    }
}


