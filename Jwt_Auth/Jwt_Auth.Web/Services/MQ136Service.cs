using Jwt_Auth.Shared.Models;
using System.Net.Http.Json;

namespace Jwt_Auth.Web.Services
{
    public class MQ136Service
    {
        private readonly HttpClient _http;

        public MQ136Service(HttpClient http)
        {
            _http = http;
        }


        public async Task<IEnumerable<MQ136Sensor>> GetAllAsync()
        {
            var result = await _http
                .GetFromJsonAsync<IEnumerable<MQ136Sensor>>("api/MQ136Sensor");

            return result ?? Enumerable.Empty<MQ136Sensor>();
        }


        public async Task<bool> AddAsync(MQ136SensorDto dto)
        {
            var response =
                await _http.PostAsJsonAsync("api/MQ136Sensor", dto);

            return response.IsSuccessStatusCode;
        }


        public async Task<bool> DeleteAsync(long id)
        {
            var response =
                await _http.DeleteAsync($"api/MQ136Sensor/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}