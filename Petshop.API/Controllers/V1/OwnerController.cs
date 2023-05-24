using Microsoft.AspNetCore.Mvc;
using Petshop.Domain.Agreggate.OwnerAggregate;

namespace Petshop.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _repository;

        public OwnerController(IOwnerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            var employees = await _repository.GetAllAsync();

            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetOwnerById(Guid id)
        {
            return Ok("ok");
        }

        [HttpGet]
        [Route("{id}/pets")]
        public async Task<IActionResult> GetPetsByOwnerId(Guid id)
        {
            return Ok("ok");
        }

        [HttpGet]
        [Route("pets")]
        public async Task<IActionResult> GetAllPets()
        {
            return Ok("ok");
        }



        [HttpGet]
        [Route("pets/{id}")]
        public async Task<IActionResult> GetPetById(Guid id)
        {
            return Ok("ok");
        }
    }
}