using Jwt_Auth.Models;
using Jwt_Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Auth.Controllers
{
   
  
        [ApiController]
        [Route("api/[controller]")]
        [Authorize(Roles = "Admin")]
        public class MQ136SensorController(IMQ136SensorService service) : ControllerBase
        {
            [HttpGet]
            public async Task<IActionResult> GetAll() => Ok(await service.GetAllAsync());

            [HttpGet("{id}")]
            public async Task<IActionResult> Get(long id)
            {
                var sensor = await service.GetByIdAsync(id);

                if (sensor == null)
                    return NotFound();

                return Ok(sensor);
            }

            [HttpPost]
            public async Task<IActionResult> Create(MQ136SensorDto dto)
            {
                var sensor = await service.AddAsync(dto);

                return Ok(sensor);
            }


            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(long id)
            {
                if (!await service.DeleteAsync(id))
                    return NotFound();

                return Ok("Deleted Successfully");
            }
        }
    }
