using System;
using System.Net;
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
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("The Zip Code that was entered was incorrect. Please try another U.S. zip code");
                    }
                    else
                    {
                        // Handle other error responses
                        throw new HttpRequestException($"Unexpected status code: {response.StatusCode}");
                    }
                }
                var stream = await response.Content.ReadAsStringAsync();
                Area data = JsonConvert.DeserializeObject<Area>(stream);
                return data;
            }
        }
    }
}

