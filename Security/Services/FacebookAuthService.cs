using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Security.Helpers;
using Security.Resources;
using System.Net.Http;
using System.Threading.Tasks;

namespace Security.Services
{
    public class FacebookAuthService : IFacebookAuthService
    {
        private readonly FBAuthSettings _facebookAuthSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public FacebookAuthService(IOptions<FBAuthSettings> facebookAuthSettings, IHttpClientFactory httpClientFactory)
        {
            _facebookAuthSettings = facebookAuthSettings.Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<FBUserInfoResult> GetUserInfoAsync(string accessToken)
        {
            var formattedUrl = string.Format(Constants.FBGetUserInfoURL, accessToken, _facebookAuthSettings.AppId, _facebookAuthSettings.AppSecret);

            var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);

            result.EnsureSuccessStatusCode();

            var responseAsString = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FBUserInfoResult>(responseAsString);
        }

        public async Task<FBTokenValidationResult> ValidateAccessTokenAsync(string accessToken)
        {
            var formattedUrl = string.Format(Constants.FBTokenValidationURL, accessToken, _facebookAuthSettings.AppId, _facebookAuthSettings.AppSecret);

            var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);

            result.EnsureSuccessStatusCode();

            var responseAsString = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FBTokenValidationResult>(responseAsString);
        }
    }
}
