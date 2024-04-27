using System;
using Newtonsoft.Json;
using WeatherApp.Common;

namespace WeatherApp.Business
{
	public class AreaService : IAreaClient
    {
        //HttpClient injected by .NET Core
        private readonly HttpClient _client;

        public AreaService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://api.zippopotam.us/us/");
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
        }

        public async Task<Area> GetAreaDetails(string ZipCode)
        {
            
            using (var response = await _client.GetAsync(ZipCode, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStringAsync();
                Area data = JsonConvert.DeserializeObject<Area>(stream);
                return data;
            }
        }
    }
}

