using Blazored.LocalStorage;
using Football.ClientApp.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Football.ClientApp.Components.UserComponent
{
    public class LogoutComponent : ComponentBase
    {
        [Inject]
        HttpClient httpClient { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await LocalStorageService.RemoveItemAsync("token");
            await LocalStorageService.RemoveItemAsync("email");

            (AuthenticationStateProvider as AuthState).NotifyUserLogout();
            httpClient.DefaultRequestHeaders.Authorization = null;

            NavigationManager.NavigateTo("/login");
        }
    }
}
