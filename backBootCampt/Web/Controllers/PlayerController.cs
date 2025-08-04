using Business.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PlayerController : GenericController<Player, PlayerDto>
    {
        public PlayerController(IBaseModelBusiness<Player, PlayerDto> business)
            : base(business)
        {

        }
    }
}
