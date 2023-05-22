using Microsoft.AspNetCore.Mvc;

namespace Petshop.API.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            return Ok("ok 2");
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetOwnerById(Guid id)
        {
            return Ok("ok 2");
        }

        [HttpGet]
        [Route("{id}/pets")]
        public async Task<IActionResult> GetPetsByOwnerId(Guid id)
        {
            return Ok("ok 2");
        }

        [HttpGet]
        [Route("pets")]
        public async Task<IActionResult> GetAllPets()
        {
            return Ok("ok 2");
        }



        [HttpGet]
        [Route("pets/{id}")]
        public async Task<IActionResult> GetPetById(Guid id)
        {
            return Ok("ok 2");
        }
    }
}