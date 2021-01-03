using System;
using Portfolio.Core.ServiceModels;
using Portfolio.Core.Services;
using Xunit;

namespace Portfolio.Tests.Core.Services.Auth
{
    public class AuthServiceTests
    {
        private readonly AuthService _authService;
        
        public AuthServiceTests()
        {
            var authRepositoryFake = new AuthRepositoryFake();
            var tokenGeneratorFake = new TokenGeneratorFake();
            _authService = new AuthService(authRepositoryFake, tokenGeneratorFake);
        }
        
        [Fact]
        public async void Login_ValidUsernameAndPassword_ReturnsToken()
        {
            var loginRequest = new LoginRequest("test", "test");
            
            var (username, token, _, _) = await _authService.Login(loginRequest);
            
            Assert.NotEmpty(token);
            Assert.Equal(loginRequest.Username, username);
        }

        [Fact]
        public async void Login_EmptyUsernameOrPassword_ReturnsAppropriateError()
        {
            var loginRequest = new LoginRequest("", "");

            var (_, _, isError, errorMessage) = await _authService.Login(loginRequest);
            
            Assert.True(isError);
            Assert.Contains("empty username or password", errorMessage, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async void Login_InvalidUsernameOrPassword_ReturnsAppropriateError()
        {
            var loginRequest = new LoginRequest("invalid-username", "invalid-password");

            var (_, _, isError, errorMessage) = await _authService.Login(loginRequest);
            
            Assert.True(isError);
            Assert.Contains("invalid username or password", errorMessage, StringComparison.OrdinalIgnoreCase);
        }
        
    }
}