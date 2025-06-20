using BibliotekaAplikacjaProjekt.Dtos;
using Newtonsoft.Json;
using PromocjeAplikacjaProjekt.Dtos;
using System.Net.Http.Headers;

namespace CzytelnikAplikacjaProjekt.Resolver
{
    public class CouponResolver
    {
        private readonly HttpClient _httpClient;

        public CouponResolver(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5075/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<CouponDto>> GetCouponsByDiscount(int readerId)
        {
            var response = await _httpClient.GetAsync($"CouponByOrder/{readerId}");
            if (!response.IsSuccessStatusCode) return new();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CouponDto>>(json) ?? new();
        }
    }
}
