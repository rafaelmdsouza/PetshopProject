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
        private readonly IPetRepository _petRepository;
        private readonly IOwnerQueries _ownerQueries;
        public OwnerController(IOwnerRepository repository, IPetRepository petRepository, IOwnerQueries ownerQueries)
        {
            _repository = repository;
            _petRepository = petRepository;
            _ownerQueries = ownerQueries;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            var employees = await _ownerQueries.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOwnerById(Guid id)
        {
            var employee = await _ownerQueries.GetById(id);

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner(string name, int age, string email, string phone)
        {
            var owner = new Owner(name, age, email, phone);

            await _repository.Add(owner);
            return Ok();
        }

        [HttpPut]
        [Route("{id}/update")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] string name)
        {
            var owner = await _repository.GetByIdAsync(id);
            owner.Update(name, "updated", "updated", 1);
            await _repository.Update(owner);
            return Ok();
        }

        [HttpPost]
        [Route("{id}/disable")]
        public async Task<IActionResult> DisableOwner(Guid id)
        {
            var owner = await _repository.GetByIdAsync(id);
            owner.Disable();
            await _repository.Update(owner);
            return Ok();
        }

        [HttpPost]
        [Route("{id}/enable")]
        public async Task<IActionResult> EnableOwner(Guid id)
        {
            var owner = await _repository.GetByIdAsync(id);
            owner.Enable();
            await _repository.Update(owner);
            return Ok();
        }

        [HttpPost]
        [Route("{id}/register_pet")]
        public async Task<IActionResult> RegisterPet(Guid id, string name, int age, PetType type)
        {
            var owner = await _repository.GetByIdAsync(id);
            if (owner == null)
                throw new Exception("Owner not found.");
                
            var pet = new Pet(owner.Id, name, age, type);
            owner.RegisterPet(pet);

            await _petRepository.Add(pet);
            await _repository.Update(owner);
            return Ok();
        }

        // [HttpGet]
        // [Route("{id}/pets")]
        // public async Task<IActionResult> GetPetsByOwnerId(Guid id)
        // {
        //     return Ok("ok");
        // }

        // [HttpGet]
        // [Route("pets")]
        // public async Task<IActionResult> GetAllPets()
        // {
        //     return Ok("ok");
        // }



        // [HttpGet]
        // [Route("pets/{id}")]
        // public async Task<IActionResult> GetPetById(Guid id)
        // {
        //     return Ok("ok");
        // }
    }
}