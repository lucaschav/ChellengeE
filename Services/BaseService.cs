using ChellengeE.Models;
using Newtonsoft.Json;

namespace ChellengeE.Services
{
    public class BaseService
    {
        private readonly IHttpClientFactory httpClient;

        public BaseService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("Challenge");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("user-agent", "News-API-csharp/0.1");
                message.Headers.Add("x-api-key", SD.ApiKey);
                message.RequestUri = new Uri(apiRequest.Url);

                HttpResponseMessage apiResponse = null;
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
                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new Exception(JsonConvert.DeserializeObject<string>(apiContent));
                }

                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;
            }
            catch (Exception error)
            {
                throw new Exception(String.IsNullOrEmpty(error.Message) ? "Ocurrio un error al realizar la consulta" : error.Message);
            }
        }
    }
}
