using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NewsFeed.AuxiliaryAdditions;
using Newtonsoft.Json;

namespace NewsFeed.Services
{
    public class WebApiServiceImplementation : IWebApiService
    {
        private HttpClient _httpClient;

        public HttpResponseMessage Result { get; set; }

        public async Task<T> GetRequest<T>(string endPoint, string keyword = "keyword")
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{APIConfig.URL}{endPoint}?q={keyword}&apiKey={APIConfig.API_KEY}")
                };
                var productValue = new ProductInfoHeaderValue("NewsFeed", "1.0");
                var commentValue = new ProductInfoHeaderValue("(+Educational program)");

                request.Headers.UserAgent.Add(productValue);
                request.Headers.UserAgent.Add(commentValue);

                var handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                };
                _httpClient = new HttpClient(handler);
                Result = await _httpClient.SendAsync(request);
                var stringContent = await Result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(stringContent);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}