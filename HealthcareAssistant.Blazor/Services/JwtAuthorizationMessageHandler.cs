using System.Net.Http.Headers;
using HealthcareAssistant.Blazor.Services;
using Microsoft.JSInterop;

namespace HealthcareAssistant.Blazor.Services;

public class JwtAuthorizationMessageHandler
    : DelegatingHandler
{
    private readonly ILocalStorageService _localStorage;

    public JwtAuthorizationMessageHandler(
        ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    protected override async Task<HttpResponseMessage>
        SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
    {
        var token =
            await _localStorage.GetItemAsync(
                "token");

        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);
        }

        return await base.SendAsync(
            request,
            cancellationToken);
    }
}