using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Auth.Demo
{
    public interface IJWTAuthenticationManager
    {
        AuthenticationResponse Authenticate(string username, string password);
        IDictionary<string, string> UsersRefreshTokens { get; set; }
        AuthenticationResponse Authenticate(string username, Claim[] claims);
    }

    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        IDictionary<string, string> users = new Dictionary<string, string>
        {
            { "test1", "password1" },
            { "test2", "password2" }
        };

        public IDictionary<string, string> UsersRefreshTokens { get; set; }

        private readonly string tokenKey;

        public JWTAuthenticationManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
            UsersRefreshTokens = new Dictionary<string, string>();
        }

        public AuthenticationResponse Authenticate(string username, Claim[] claims)
        {
            var token = GenerateTokenString(username, DateTime.UtcNow, claims);


            return new AuthenticationResponse
            {
                JwtToken = token,
            };
        }

        public AuthenticationResponse Authenticate(string username, string password)
        {
            if (!users.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }

            var token = GenerateTokenString(username, DateTime.UtcNow);

            return new AuthenticationResponse
            {
                JwtToken = token,
            };
        }

        string GenerateTokenString(string username, DateTime expires, Claim[] claims = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                 claims ?? new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                //NotBefore = expires,
                Expires = expires.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}