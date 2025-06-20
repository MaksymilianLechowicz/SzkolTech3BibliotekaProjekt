using BibliotekaAplikacjaProjekt.Dtos;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CzytelnikAplikacjaProjekt.Resolver
{
    public class OrderResolver
    {

        private readonly HttpClient _httpClient;

        public OrderResolver(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5003/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<OrderDto>> GetOrdersByReaderId(int readerId)
        {
            var response = await _httpClient.GetAsync($"OrdersBuy/{readerId}");
            if (!response.IsSuccessStatusCode) return new();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OrderDto>>(json) ?? new();
        }
    }
}
