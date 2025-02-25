using Newtonsoft.Json;
using Postnummer.ViewModels;
using System.Net.Http;
using Postnummer.Models.Api;

namespace Postnummer.Services
{
    // Interface

    public interface IApiService
    {
        Task<List<Result>>GetPostalCodeListBySearch(string search);
    }

    // Class

    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient("searchPostalCode");
            _configuration = configuration;
        }

        // methods

        public async Task<List<Result>> GetPostalCodeListBySearch(string search)
        {
            // Api details

            string apiKey = _configuration.GetSection("PostalCodeApi:ApiKey").Value;
            string apiEndpoint = $"?query={search}&format=json&apikey={apiKey}";

            // Communication with api

            var postCodeRespons = await _httpClient.GetStringAsync(apiEndpoint);

            PostCode obj = JsonConvert.DeserializeObject<PostCode>(postCodeRespons);
    
            return obj.results.ToList();
        }
    }
}
