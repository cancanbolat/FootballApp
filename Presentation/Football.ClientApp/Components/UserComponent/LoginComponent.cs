using Blazored.LocalStorage;
using Football.Application.DTO;
using Football.ClientApp.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Football.ClientApp.Components.UserComponent
{
    public class LoginComponent : ComponentBase
    {
        [Inject]
        HttpClient httpClient { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        public UserLoginRequestDTO loginRequestDTO = new UserLoginRequestDTO();

        public async Task LoginProcess()
        {
            var httpReq = await httpClient.PostAsJsonAsync("api/user/login", loginRequestDTO);

            if (httpReq.IsSuccessStatusCode)
            {
                try
                {
                    var res = await httpReq.Content.ReadFromJsonAsync<UserLoginReponseDTO>();

                    if (!string.IsNullOrEmpty(res.ApiToken))
                    {
                        await LocalStorageService.SetItemAsync("token", res.ApiToken.ToString());
                        await LocalStorageService.SetItemAsync("email", res.UserDTO.Email.ToString());

                        (AuthenticationStateProvider as AuthState).NotifyUserLogin(res.UserDTO.Email);

                        httpClient.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", res.ApiToken);

                        NavigationManager.NavigateTo("/");
                    }
                    else
                    {
                        NavigationManager.NavigateTo("/login");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
