using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace Core.Meteor.Token
{
    public class TokenClient
    {
        public HttpClient Client { get; }
        public TokenClientOptions Options { get; }

        public TokenClient(HttpClient client, IOptions<TokenClientOptions> options)
        {
            Client = client;
            Options = options.Value;
        }

        public async Task<string> GetToken()
        {
            var response = await Client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = Options.Address,
                ClientId = Options.ClientId,
                ClientSecret = Options.ClientSecret
            });

            return response.AccessToken ?? response.Error;
        }
    }
}
