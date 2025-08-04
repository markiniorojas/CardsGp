using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Dto;
using Entity.Model;

namespace Business.AutoMapper
{
    public class AutoMapperModel : Profile
    {
        public AutoMapperModel() 
        {
            CreateMap<Card,CardDto>();
            CreateMap<CardDto,Card>();

            CreateMap<Player,PlayerDto>();
            CreateMap<PlayerDto,Player>();

            CreateMap<Games,GamesDto>();
            CreateMap<GamesDto, Games>();

            CreateMap<GamePlayer, GamePlayerDto>();
            CreateMap<GamePlayerDto, GamePlayer>();

            CreateMap<PlayerCard, PlayerCardDto>();
            CreateMap<PlayerCardDto, PlayerCard>();
        }
    }
}
