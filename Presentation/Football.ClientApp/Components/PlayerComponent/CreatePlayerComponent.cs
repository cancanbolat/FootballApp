using Football.Application.Wrappers;
using Football.Core.Application.DTO;
using Football.Core.Application.Features.Commands.Players;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Football.ClientApp.Components.PlayerComponent
{
    public class CreatePlayerComponent : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        private HubConnection hubConnection { get; set; }

        protected List<TeamDTO> Teams = new List<TeamDTO>();
        protected List<PositionDTO> Positions = new List<PositionDTO>();

        protected CreatePlayerCommand command = new CreatePlayerCommand();

        protected async override Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri("/broadcastHub")).Build();
            await hubConnection.StartAsync();

            await LoadTeams();
            await LoadPositions();
        }

        Task SendMessage() => hubConnection.SendAsync("SendMessage");
        public bool IsConnected => hubConnection.State == HubConnectionState.Connected;

        protected async Task Create()
        {
            await Http.PostAsJsonAsync("api/player/create", command);
            if (IsConnected) await SendMessage();
            NavigationManager.NavigateTo("playerlist");
        }

        protected async Task LoadTeams()
        {
            var response = await Http.GetFromJsonAsync<ServiceResponse<List<TeamDTO>>>("api/team/all");

            if (response.Success)
                Teams = response.Value;
        }

        protected async Task LoadPositions()
        {
            var response = await Http.GetFromJsonAsync<ServiceResponse<List<PositionDTO>>>("api/position/all");

            if (response.Success)
                Positions = response.Value;
        }
    }
}
