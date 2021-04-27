using Security.Helpers;
using System.Threading.Tasks;

namespace Security.Services
{
    public interface IFacebookAuthService
    {
        Task<FBTokenValidationResult> ValidateAccessTokenAsync(string accessToken);
        Task<FBUserInfoResult> GetUserInfoAsync(string accessToken);
    }
}
