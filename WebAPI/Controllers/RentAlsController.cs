using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentAlsController : ControllerBase
    {
        IRentAlService _rentAlService;
        public RentAlsController(IRentAlService rentAlService)
        {
            _rentAlService = rentAlService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentAlService.GetAll();
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentAlService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }
        [HttpPost("add")]
        public IActionResult Add(RentAl rental)
        {
            var result = _rentAlService.Add(rental);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(RentAl rental)
        {
            var result = _rentAlService.Delete(rental);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }
        [HttpPost("update")]
        public IActionResult Update(RentAl rental)
        {
            var result = _rentAlService.Update(rental);
            if (result.Success) { return Ok(result); }
            return BadRequest();
        }
    }
}
