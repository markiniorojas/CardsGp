using Business.Interface;
using Entity.Base;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class GenericController <TEntity,TDto> : ControllerBase
        where TEntity : BaseModel
        where TDto : BaseDto
    {
        private readonly IBaseModelBusiness<TEntity, TDto> _business;

        public GenericController(IBaseModelBusiness<TEntity, TDto> business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDto>>> GetAll()
        {
            var result = await _business.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDto>> GetById(int id)
        {
            var result = await _business.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TDto>> Create([FromBody] TDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _business.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _business.deleteLogico(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
