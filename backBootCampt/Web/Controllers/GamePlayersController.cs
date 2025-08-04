using Business.Interface;
using Entity.Dto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class GamePlayersController : GenericController<GamePlayer, GamePlayerDto>
    {
        public GamePlayersController(IBaseModelBusiness<GamePlayer, GamePlayerDto> business)
            : base(business)
        {

        }
    }
}
