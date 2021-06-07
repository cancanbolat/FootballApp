using Football.Application.DTO;
using Football.Application.Wrappers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Football.ClientApp.Components.PlayerComponent
{
    public class PlayerTableComponent : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        private HubConnection hubConnection { get; set; }

        protected List<PlayerDTO> PlayerList = new List<PlayerDTO>();


        protected async override Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri("/broadcastHub")).Build();

            hubConnection.On("ReceiveMessage", () =>
            {
                CallLoadData();
                StateHasChanged();
            });

            await hubConnection.StartAsync();
            await Load();
        }

        protected async Task Load()
        {
            var response = await Http.GetFromJsonAsync<ServiceResponse<List<PlayerDTO>>>("api/player/all");

            if (response.Success)
            {
                PlayerList = response.Value;
                StateHasChanged();
            }
        }

        protected void CallLoadData()
        {
            Task.Run(async () =>
            {
                await Load();
            });
        }

    }
}
