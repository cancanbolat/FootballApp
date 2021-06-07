using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Football.ClientApp.Auth
{
    public class AuthState : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorageService;
        private readonly HttpClient httpClient;
        private readonly AuthenticationState anonymusUser;

        public AuthState(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            this.localStorageService = localStorageService;
            this.httpClient = httpClient;
            anonymusUser = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string apiToken = await localStorageService.GetItemAsStringAsync("token");

            if (string.IsNullOrEmpty(apiToken))
                return anonymusUser;

            string email = await localStorageService.GetItemAsStringAsync("email");
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuth"));

            httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiToken);

            return new AuthenticationState(claimsPrincipal);
        }

        public void NotifyUserLogin(string email)
        {
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuth"));

            var authState = Task.FromResult(new AuthenticationState(claimsPrincipal));

            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(anonymusUser);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
