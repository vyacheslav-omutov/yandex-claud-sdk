using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Yandex.ID.Enums;
using Yandex.ID.Exceptions;
using Yandex.ID.Helpers;
using Yandex.ID.Options.Authorization;
using Yandex.ID.Requests;
using Yandex.ID.Requests.Authorization;
using Yandex.ID.Responses;
using Yandex.ID.Responses.Errors;

namespace Yandex.ID.Services.Authorization;

public class YandexAuthorizationService(IOptions<YandexApplicationOption> applicationOptions, 
    IHttpClientFactory httpClientFactory) : IYandexAuthorizationService
{
    private readonly YandexApplicationOption _applicationOption = applicationOptions.Value;
    private readonly HttpClient _authorizationClient = httpClientFactory.CreateClient("YandexAuthorization");
    
    public Task<string> GetUrlForRequestCodeAsync(YandexAuthorizeRequest? yandexRequest = null)
    {
        var url = $"{_authorizationClient.BaseAddress}authorize";
        var request = yandexRequest ?? new YandexAuthorizeRequest(ResponseType.Code, _applicationOption.ClientId);
        
        var queryParams = UriHelper.CreateQueryParamsFromRequest(request);
        var queryString = QueryHelpers.AddQueryString(url, queryParams);
        return Task.FromResult(new Uri(queryString).ToString());
    }

    public async Task<YandexTokenResponse> GetTokenAsync(string code)
    {
        ArgumentNullException.ThrowIfNull(code);
        
        var credentialsBytes = Encoding.ASCII.GetBytes($"{_applicationOption.ClientId}:{_applicationOption.ClientSecret}");
        var credentials = Convert.ToBase64String(credentialsBytes);
        var authenticationHeaderValue = new AuthenticationHeaderValue("Basic", credentials);
        var mediaTypeHeaderValue = new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded");
        
        _authorizationClient.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
        _authorizationClient.DefaultRequestHeaders.Accept.Add(mediaTypeHeaderValue);
        
        var tokenRequest = new YandexTokenRequest("authorization_code", code);
        var queryParams = UriHelper.CreateQueryParamsFromRequest(tokenRequest);
        var httpContent = new FormUrlEncodedContent(queryParams);
        
        var response = await _authorizationClient.PostAsync("token", httpContent);
        if (!response.IsSuccessStatusCode)
        {
            string errorMessage;
            var errorResponse = await response.Content.ReadFromJsonAsync<YandexErrorResponse>();
            if (errorResponse != null)
            {
                errorMessage = $"Error: {errorResponse.Error}.\nDescription: {errorResponse.ErrorDescription}.\nState: {errorResponse.State}";
                throw new YandexAuthorizationException(errorMessage);
            }
            
            errorMessage = await response.Content.ReadAsStringAsync();
            throw new YandexAuthorizationException($"{errorMessage}");
        }
        
        var yandexResponse = await response.Content.ReadFromJsonAsync<YandexTokenResponse>();
        if (yandexResponse == null)
        {
            throw new YandexAuthorizationException("Yandex token response could not be deserialized.");
        }
        
        return yandexResponse;
    }
}