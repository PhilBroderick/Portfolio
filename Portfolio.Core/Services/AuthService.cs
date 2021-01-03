using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.JsonWebTokens;
using Portfolio.Core.Interfaces.Repositories;
using Portfolio.Core.Interfaces.Services;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtGenerator _tokenGenerator;

        public AuthService(IAuthRepository authRepository, IJwtGenerator tokenGenerator)
        {
            _authRepository = authRepository;
            _tokenGenerator = tokenGenerator;
        }
        
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var (username, password) = loginRequest;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return new LoginResponse(username, password, true, "Empty username or password");

            if (!await _authRepository.ValidateUser(username, password))
                return new LoginResponse(username, password, true, "Invalid username or password");

            var claims = GenerateClaims(username);

            var jwtToken = _tokenGenerator.GenerateToken(username, claims.ToArray(), DateTime.Now);

            return new LoginResponse(username, jwtToken);
        }

        private static IEnumerable<Claim> GenerateClaims(string username) => new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username)
        };
    }
}