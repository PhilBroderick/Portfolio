namespace Portfolio.Core.ServiceModels
{
    public record LoginRequest(string Username, string Password);

    public record LoginResponse(string Username, string Token, bool IsError = false, string ErrorMessage = "");
}