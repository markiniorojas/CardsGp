using System.Text.Json.Serialization;
using Business.Implemets;
using Business.Interface;
using Data;
using Data.@interface;
using Entity.Dto;
using Entity.Model;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace Web.ServicesExtensions
{
    public static class ServicesDependency 
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseModelData<,>), typeof(BaseModelData<,>));

            services.AddScoped(typeof(IBaseModelBusiness<Player, PlayerDto>), typeof(BaseModelBusiness<Player, PlayerDto>));
            services.AddScoped(typeof(IBaseModelBusiness<Card, CardDto>), typeof(BaseModelBusiness<Card, CardDto>));
            services.AddScoped(typeof(IBaseModelBusiness<Games, GamesDto>), typeof(BaseModelBusiness<Games, GamesDto>));
            services.AddScoped(typeof(IBaseModelBusiness<GamePlayer, GamePlayerDto>), typeof(BaseModelBusiness<GamePlayer, GamePlayerDto>));
            services.AddScoped(typeof(IBaseModelBusiness<PlayerCard, PlayerCardDto>), typeof(BaseModelBusiness<PlayerCard, PlayerCardDto>));

            return services;
        }
    }
}
