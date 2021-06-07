using AutoMapper;
using Football.Application.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Football.Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddConfigureApplication(this IServiceCollection services)
        {
            //AutoMapper
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
