using System;
using System.Net.Http;
using System.Threading.Tasks;
using BikeApp.Models.ForecastData;
using Newtonsoft.Json;

namespace BikeApp.Services
{
    public class RestService
    {
        HttpClient _client;
        public RestService()
        {
            _client = new HttpClient();
        }
        public async Task<Root> GetForecastData(string query)
        {
            Root forecastData = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    forecastData = JsonConvert.DeserializeObject<Root>(content);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return forecastData;
        }
    }
}
