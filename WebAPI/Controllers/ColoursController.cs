using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoursController : Controller
    {
        IColourService _colourService;

        public ColoursController(IColourService colourService)
        {
            _colourService = colourService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colourService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int colourId)
        {
            var result = _colourService.GetById(colourId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Colour colour)
        {
            var result = _colourService.Add(colour);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Colour colour)
        {
            var result = _colourService.Delete(colour);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Colour colour)
        {
            var result = _colourService.Update(colour);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}