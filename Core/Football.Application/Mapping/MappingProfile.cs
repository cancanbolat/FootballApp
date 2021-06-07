using AutoMapper;
using Football.Application.DTO;
using Football.Application.Features.Commands.Users;
using Football.Core.Application.DTO;
using Football.Core.Application.Features.Commands.Players;
using Football.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Settings
            AllowNullDestinationValues = true;
            AllowNullCollections = true;

            //Users
            CreateMap<User, LoginUserCommand>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

            //Player
            CreateMap<Player, PlayerDTO>().ReverseMap();
            CreateMap<Player, DetailedPlayerDTO>().ReverseMap();
            CreateMap<Player, CreatePlayerCommand>().ReverseMap();

            //Team
            CreateMap<Team, TeamDTO>()
                .ForMember(x => x.TeamName, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.TeamLogo, y => y.MapFrom(z => z.Logo));

            //Position
            CreateMap<Position, PositionDTO>()
                .ForMember(x => x.PositionName, y => y.MapFrom(z => z.Name));
        }
    }
}
