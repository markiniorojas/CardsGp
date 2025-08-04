using Business.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CardController : GenericController<Card, CardDto>
    {
        public CardController(IBaseModelBusiness<Card,CardDto> business)
            : base(business)
        {

        }
    }
}
