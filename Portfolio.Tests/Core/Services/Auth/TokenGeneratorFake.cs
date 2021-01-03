using System;
using System.Security.Claims;
using Portfolio.Core.Interfaces.Services;

namespace Portfolio.Tests.Core.Services.Auth
{
    public class TokenGeneratorFake : IJwtGenerator
    {
        public string GenerateToken(string username, Claim[] claims, DateTime now)
        {
            return "stubbed-token";
        }
    }
}