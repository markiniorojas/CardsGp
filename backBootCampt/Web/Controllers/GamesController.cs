using Business.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class GamesController : GenericController<Games, GamesDto>
    {
        public GamesController(IBaseModelBusiness<Games, GamesDto> business)
            : base(business)
        {

        }
    }
}
