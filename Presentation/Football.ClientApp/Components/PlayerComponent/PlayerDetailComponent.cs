using Football.Application.DTO;
using Football.Application.Wrappers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Football.ClientApp.Components.PlayerComponent
{
    public class PlayerDetailComponent : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        protected DetailedPlayerDTO PlayerDetail = new DetailedPlayerDTO();

        [Parameter]
        public string id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var response = await Http.GetFromJsonAsync<ServiceResponse<DetailedPlayerDTO>>($"api/player/{id}");

            if (response.Success)
                PlayerDetail = response.Value;
        }
    }
}
