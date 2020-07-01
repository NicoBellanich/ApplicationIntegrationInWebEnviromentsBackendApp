using System.Threading.Tasks;
using Tiny.RestClient;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace AWSSeerverlessAPI.Authorization
{
    public class AuthorizationHelper
    {
        private static OAuthAccessToken accessToken;

        private static ILogger<AuthorizationHelper> _logger;
        private static IConfiguration _config;
        public AuthorizationHelper(ILogger<AuthorizationHelper> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }
        public async static Task<string> ObtenerAccessToken()
        {
            if (accessToken  == null)
            {
                var clientOAuth = new TinyRestClient(new HttpClient(),"https://dev-utn-frc-iaew.auth0.com/oauth");

                var request = new OAuthRequest()
                {
                    audience = "https://www.example.com/reservas",
                    client_id = "Gd23b2IQ7awzx1PueJw2XhZSL9HAD6wT",
                    client_secret = "gao2QIPgFpmFRKRjRn6tfHwFTLQLmqin77wwC-XOM5Vi6P57KHV14nQIYITZaZr_",
                    grant_type = "client_credentials"
                    
                };

                accessToken = await clientOAuth.PostRequest("token", request).
                                    ExecuteAsync<OAuthAccessToken>();

            }

            return accessToken.access_token;

        }
    }
}