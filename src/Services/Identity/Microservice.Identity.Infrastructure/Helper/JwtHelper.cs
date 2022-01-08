using Microservice.Identity.Domain.Entity;
using Microservice.Identity.Infrastructure.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Infrastructure.Helper
{
    public class JwtHelper
    {

        #region CreateUserAccessToken
        public static UserToken CreateUserAccessToken(User user, TokenOptions tokenOptions)
        {
            ValidateTokenOptions(tokenOptions);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));
            var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            var expireDate = DateTime.Now.AddDays(tokenOptions.UserAccessTokenExpiration);

            var userJwtToken = CreateUserAccessToken(tokenOptions, user, signInCredentials, expireDate);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtTokenHandler.WriteToken(userJwtToken);

            return new UserToken()
            {
                Token = token,
                Expiration = expireDate,
                UserId = user.Id,
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName,
                PictureName = user.PictureName,
                LastLoginDate = user.LastLoginDate
            };
        }



        private static JwtSecurityToken CreateUserAccessToken(TokenOptions tokenOptions, User user, SigningCredentials signInCredentials, DateTime expireDate)
        {
            return new JwtSecurityToken
                (
                    audience: tokenOptions.Audience,
                    issuer: tokenOptions.Issuer,
                    expires: expireDate,
                    notBefore: DateTime.Now,
                    claims: GetUserClaims(user),
                    signingCredentials: signInCredentials
                );
        }



        private static List<Claim> GetUserClaims(User user)
        {            
            return new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.Name} {user.LastName}"),
                new Claim("user-picture-name", user.PictureName),
                new Claim("last-login-date", user.LastLoginDate.ToString()),
                new Claim("token-type", "UserToken"),
            };
        }

        #endregion


        #region CreateClientToken
        public static ClientToken CreateClientAccessToken(SubscribedClient client, TokenOptions tokenOptions)
        {
            ValidateTokenOptions(tokenOptions);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));
            var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            var expireDate = DateTime.Now.AddDays(tokenOptions.ClientAccessTokenExpiration);

            var userJwtToken = CreateClientAccessToken(tokenOptions, client, signInCredentials, expireDate);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtTokenHandler.WriteToken(userJwtToken);

            return new ClientToken()
            {
                Token = token,
                Expiration = expireDate,
                ClientId = client.Id
                
            };
        }



        private static JwtSecurityToken CreateClientAccessToken(TokenOptions tokenOptions, SubscribedClient client, SigningCredentials signInCredentials, DateTime expireDate)
        {
            return new JwtSecurityToken
                (
                    audience: tokenOptions.Audience,
                    issuer: tokenOptions.Issuer,
                    expires: expireDate,
                    notBefore: DateTime.Now,
                    claims: GetClientClaims(client),
                    signingCredentials: signInCredentials
                );
        }



        private static List<Claim> GetClientClaims(SubscribedClient client)
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, client.Id),             
            };
        }
        #endregion


        #region ValidateTokenOptions
        private static void ValidateTokenOptions(TokenOptions tokenOptions)
        {
            if (tokenOptions == null ||
                string.IsNullOrEmpty(tokenOptions.Issuer) ||
                string.IsNullOrEmpty(tokenOptions.Audience) ||
                string.IsNullOrEmpty(tokenOptions.SecurityKey) ||
                tokenOptions.UserAccessTokenExpiration <= 0 ||
                tokenOptions.ClientAccessTokenExpiration <= 0)
            {
                throw new ArgumentNullException("TokenOptions is Null.");
            }
        }
        #endregion

    }
}
