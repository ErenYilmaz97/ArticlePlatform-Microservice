using Castle.DynamicProxy;
using Microservices.Core.Constants;
using Microservices.Core.Dtos;
using Microservices.Core.Enum;
using Microservices.Core.Utilities.Interceptor;
using Microservices.Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Aspects.Authorize
{
    public class AuthorizeAspect : MethodInterceptor
    {
        //TODO : PermissionType
        private PermissionType _permission;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient _httpClient;
        private AuthenticationType _authType;

        public AuthorizeAspect(PermissionType permissionType)
        {
            this._permission = permissionType;
            this._contextAccessor = null;  //Service Provider tarafıdndan gelecek
        }

        public AuthorizeAspect()
        {
            this._contextAccessor = null;
        }


        public override async void Intercept(IInvocation invocation)
        {
            string tokenType = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "token-type")?.Value;

            _authType = tokenType switch
            {
                "client-token" => AuthenticationType.ClientAuthentication,
                "user-token" => AuthenticationType.UserAuthentication,
                _ => throw new AuthenticationException("Invalid Token.")
            };

            if(_authType == AuthenticationType.ClientAuthentication)
            {
                bool isValid = true;
                string clientId = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(clientId)) throw new AuthenticationException("Invalid Token.");

                var request = new ValidateClientRequest()
                {
                    ClientId = clientId
                };

                var validateClientResponse = _httpClient.PostAsJsonAsync<ValidateClientRequest>(MicroservicesConstants.AuthenticateClientEndpoint, request).GetAwaiter().GetResult();

                if (validateClientResponse.IsSuccessStatusCode)
                {
                    var responseContent = validateClientResponse.Content.ReadFromJsonAsync<ValidateClientResponse>().GetAwaiter().GetResult();

                    if(responseContent == null || responseContent.ResultCode != ResultCodes.Success)
                    {
                        isValid = false;
                    }
                }
                else
                {
                    isValid = false;
                }

                if (!isValid) throw new AuthenticationException("Invalid Client.");
            }

            else
            {
                bool isValid = true;
                string userId = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userId)) throw new AuthenticationException("Invalid token.");

                var request = new ValidateUserRequest()
                {
                    UserId = userId,
                    Permission = _permission
                };

                var validateUserResponse = _httpClient.PostAsJsonAsync<ValidateUserRequest>(MicroservicesConstants.AuthenticateUserEndpoint, request).GetAwaiter().GetResult();

                if (validateUserResponse.IsSuccessStatusCode)
                {
                    var responseContent = validateUserResponse.Content.ReadFromJsonAsync<ValidateUserResponse>().GetAwaiter().GetResult();

                    if (responseContent == null || responseContent.ResultCode != ResultCodes.Success)
                    {
                        isValid = false;
                    }
                }
                else
                {
                    isValid = false;
                }

                if (!isValid) throw new AuthenticationException("Invalid User.");
            }

            //Authentication Success
            invocation.Proceed();
        }
    }
}
