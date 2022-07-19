using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Core.Common.Helpers
{
    public class CustomConfigurationBuilder
    {
        private readonly string _settingClientId;
        private readonly string _settingClientSecret;
        private readonly string _settingBaseAddress;
        private readonly string _settingRequestUri;

        public CustomConfigurationBuilder(string settingClientId, string settingClientSecret, string settingBaseAddress,
            string settingRequestUri)
        {
            _settingClientId = settingClientId;
            _settingClientSecret = settingClientSecret;
            _settingBaseAddress = settingBaseAddress;
            _settingRequestUri = settingRequestUri;
        }

        public JObject? Get()
        {
            JObject? result = null;
            string credentials = $"{_settingClientId}:{_settingClientSecret}";
            using var client = new HttpClient {BaseAddress = new Uri(_settingBaseAddress)};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));
            HttpResponseMessage response = client.GetAsync(_settingRequestUri.TrimEnd('/')).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                // TODO: replace ReadAsAsync() with ReadFromJsonAsync()
                result = response.Content.ReadFromJsonAsync<JObject>().GetAwaiter().GetResult();
            }

            return result;
        }
    }
}