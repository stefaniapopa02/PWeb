using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Infrastructure.Authorization;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;
using MobyLabWebProgramming.Infrastructure.Extensions;

namespace MobyLabWebProgramming.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AnimalController : AuthorizedController
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService, IUserService userService) : base(userService)
        {
            _animalService = animalService;
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RequestResponse<AnimalDTO>>> GetById([FromRoute] Guid id)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _animalService.GetAnimal(id)) :
                this.ErrorMessageResult<AnimalDTO>(currentUser.Error);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<RequestResponse<PagedResponse<AnimalDTO>>>> GetPage([FromQuery] PaginationSearchQueryParams pagination)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _animalService.GetAnimals(pagination)) :
                this.ErrorMessageResult<PagedResponse<AnimalDTO>>(currentUser.Error);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<RequestResponse>> Add([FromBody] AnimalDTO animal)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _animalService.AddAnimal(animal, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<RequestResponse>> Update([FromBody] AnimalDTO animal)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _animalService.UpdateAnimal(animal, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<RequestResponse>> Delete([FromRoute] Guid id)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _animalService.DeleteAnimal(id, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }
    }

}
