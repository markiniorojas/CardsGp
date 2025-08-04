using Business.Interface;
using Entity.Dto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PlayerCardController : GenericController<PlayerCard, PlayerCardDto>
    {
        public PlayerCardController(IBaseModelBusiness<PlayerCard, PlayerCardDto> business)
            : base(business)
        {

        }
    }
}
