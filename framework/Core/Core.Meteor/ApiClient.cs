using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Meteor.Utils;

namespace Core.Meteor
{
    public class ApiClient
    {
        private readonly HttpClient _client;

        public ApiClient(HttpClient client)
        {
            _client = client;
        }

        public static string GetUrl(string serviceName, string? modelName = null, string? suffix = null)
        {
            var service = SqServices.GetService(serviceName);
            return service == null
                ? throw Errors.NotFound($"service_name={serviceName}")
                : new Uri(new Uri(service.BaseUrl), $"{modelName}/{suffix??""}").ToString();
        }

        // Get
        public Task<T?> GetAsync<T>(string url) =>
            ReadResponse<T>(_client.GetAsync(url, HttpCompletionOption.ResponseContentRead));

        public Task<T?> GetAsync<T>(string service, string? model, string? suffix = null) =>
            GetAsync<T>(GetUrl(service, model, suffix));

        // Get With Body
        public Task<T2?> GetAsync<T, T2>(string url, T body)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var requestBody = body?.ToJson() ?? "null";
            request.Content = new StringContent(requestBody, Encoding.UTF8, MediaTypeNames.Application.Json);
            return ReadResponse<T2>(_client.SendAsync(request, HttpCompletionOption.ResponseContentRead));
        }

        public Task<T2?> GetAsync<T, T2>(T body, string service, string? model, string? suffix = null) =>
            GetAsync<T, T2>(GetUrl(service, model, suffix), body);

        // Post
        public Task<T2?> PostAsync<T, T2>(string url, T body) =>
            ReadResponse<T2>(_client.PostAsync(url, new StringContent(body?.ToJson() ?? "null", Encoding.UTF8, MediaTypeNames.Application.Json)));

        public Task<T2?> PostAsync<T, T2>(T body, string service, string? model, string? suffix = null) =>
            PostAsync<T, T2>(GetUrl(service, model, suffix), body);

        // Put
        public Task<T2?> PutAsync<T, T2>(string url, T body) =>
            ReadResponse<T2>(_client.PutAsync(url, new StringContent(body?.ToJson() ?? "null", Encoding.UTF8, MediaTypeNames.Application.Json)));

        public Task<T2?> PutAsync<T, T2>(T body, string service, string? model, string? suffix = null) =>
            PutAsync<T, T2>(GetUrl(service, model, suffix), body);

        // Delete
        public Task<T?> DeleteAsync<T>(string url) =>
            ReadResponse<T>(_client.DeleteAsync(url));

        public Task<T?> DeleteAsync<T>(string service, string? model, string? suffix = null) =>
            DeleteAsync<T>(GetUrl(service, model, suffix));

        // Delete With Body
        public Task<T2?> DeleteAsync<T, T2>(string url, T body)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            var requestBody = body?.ToJson() ?? "null";
            request.Content = new StringContent(requestBody, Encoding.UTF8, MediaTypeNames.Application.Json);
            return ReadResponse<T2>(_client.SendAsync(request, HttpCompletionOption.ResponseContentRead));
        }
        public Task<T2?> DeleteAsync<T, T2>(T body, string service, string? model, string? suffix = null) =>
            DeleteAsync<T, T2>(GetUrl(service, model, suffix), body);


        private static async Task<T?> ReadResponse<T>(Task<HttpResponseMessage> response)
        {
            var res = await response;
            res.EnsureSuccessStatusCode();
            res.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(MediaTypeNames.Application.Json);
            return await res.Content.ReadFromJsonAsync<T>();
        }
    }
}
