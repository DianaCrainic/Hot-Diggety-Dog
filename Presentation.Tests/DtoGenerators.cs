using Domain.Dtos.Account;
using System.Collections.Generic;
using System.Web.Helpers;

namespace Presentation.Tests
{
    public static class DtoGenerators
    {
        public static List<RegisterRequest> Get10000RegisterDtos()
        {
            List<RegisterRequest> _regRequests = new();
            for (int i = 0; i < 10000; i++)
            {
                RegisterRequest _request = new();
                _request.Username = $"UserName{i}";
                _request.Email = $"{_request.Username}@gmail.com";
                _request.Password = Crypto.SHA256(_request.Username);
                _regRequests.Add(_request);
            }

            return _regRequests;
        }

        public static List<AuthenticateRequest> Get10000AuthenticateDtos()
        {
            List<AuthenticateRequest> _authRequests = new();
            for (int i = 0; i < 10000; i++)
            {
                AuthenticateRequest _request = new();
                _request.Username = "customer";
                _request.Password = "customer";
                _authRequests.Add(_request);
            }

            return _authRequests;
        }
    }
}
