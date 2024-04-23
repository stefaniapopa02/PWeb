using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Infrastructure.Authorization;
using MobyLabWebProgramming.Infrastructure.Services.Implementations;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;
using MobyLabWebProgramming.Infrastructure.Extensions;

namespace MobyLabWebProgramming.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BreedController : AuthorizedController
    {
        private readonly IBreedService _breedService;
       
        public BreedController(IBreedService breedService, IUserService userService) : base(userService)
        {  
            _breedService = breedService;
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RequestResponse<BreedDTO>>> GetById([FromRoute] Guid id)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _breedService.GetBreed(id)) :
                this.ErrorMessageResult<BreedDTO>(currentUser.Error);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<RequestResponse<PagedResponse<BreedDTO>>>> GetPage([FromQuery] PaginationSearchQueryParams pagination)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _breedService.GetBreeds(pagination)) :
                this.ErrorMessageResult<PagedResponse<BreedDTO>>(currentUser.Error);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<RequestResponse>> Add([FromBody] BreedDTO breed)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _breedService.AddBreed(breed, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<RequestResponse>> Update([FromBody] BreedDTO breed)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _breedService.UpdateBreed(breed, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<RequestResponse>> Delete([FromRoute] Guid id)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _breedService.DeleteBreed(id, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }
    }

}
