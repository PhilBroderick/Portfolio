using System;
using System.Security.Claims;

namespace Portfolio.Core.Interfaces.Services
{
    public interface IJwtGenerator
    {
        string GenerateToken(string username, Claim[] claims, DateTime now);
    }
}