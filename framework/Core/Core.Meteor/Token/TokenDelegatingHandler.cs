using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Core.Meteor.Token
{
    public class TokenDelegatingHandler : DelegatingHandler
    {
        private readonly TokenClient _tokenClient;

        public TokenDelegatingHandler(TokenClient tokenClient)
        {
            _tokenClient = tokenClient;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var res = await base.SendAsync(request, cancellationToken);

            if (res.StatusCode == HttpStatusCode.Unauthorized)
            {
                var token = await _tokenClient.GetToken();
                request.SetBearerToken(token);
                res = await base.SendAsync(request, cancellationToken);
            }

            return res;
        }
    }
}
