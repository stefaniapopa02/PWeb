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
    public class ShelterController : AuthorizedController
    {
        private readonly IShelterService _shelterService;

        public ShelterController(IShelterService shelterService, IUserService userService) : base(userService)
        {
            _shelterService = shelterService;
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RequestResponse<ShelterDTO>>> GetById([FromRoute] Guid id)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _shelterService.GetShelter(id)) :
                this.ErrorMessageResult<ShelterDTO>(currentUser.Error);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<RequestResponse<PagedResponse<ShelterDTO>>>> GetPage([FromQuery] PaginationSearchQueryParams pagination)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _shelterService.GetShelters(pagination)) :
                this.ErrorMessageResult<PagedResponse<ShelterDTO>>(currentUser.Error);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<RequestResponse>> Add([FromBody] ShelterDTO shelter)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _shelterService.AddShelter(shelter, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }


        [Authorize]
        [HttpPost("{shelterId:guid}/addBreed/{breedId:guid}")]
        public async Task<ActionResult<RequestResponse>> AddBreedtoShelter(Guid shelterId, Guid breedId)
        {
            var currentUser = await GetCurrentUser();
            if (currentUser.Result != null)
            {
                var result = await _shelterService.AddBreedToShelter(shelterId, breedId);
                return this.FromServiceResponse(result);
            }
            return this.ErrorMessageResult(currentUser.Error);
        }

        /// <summary>
        /// Removes an ingredient from a food item.
        /// </summary>
        [Authorize]
        [HttpDelete("{shelterId:guid}/removeBreed/{breedId:guid}")]
        public async Task<ActionResult<RequestResponse>> RemoveIngredientFromFood(Guid shelterId, Guid breedId)
        {
            var currentUser = await GetCurrentUser();
            if (currentUser.Result != null)
            {
                var result = await _shelterService.RemoveBreedFromShelter(shelterId, breedId);
                return this.FromServiceResponse(result);
            }
            return this.ErrorMessageResult(currentUser.Error);
        }



        [Authorize]
        [HttpPut]
        public async Task<ActionResult<RequestResponse>> Update([FromBody] ShelterDTO shelter)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _shelterService.UpdateShelter(shelter, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<RequestResponse>> Delete([FromRoute] Guid id)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _shelterService.DeleteShelter(id, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }
    }

}
