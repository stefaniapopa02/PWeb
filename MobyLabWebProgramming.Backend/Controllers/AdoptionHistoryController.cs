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
    public class AdoptionHistoryController : AuthorizedController
    {
        private readonly IAdoptionHistoryService _adoptionHistoryService;

        public AdoptionHistoryController(IAdoptionHistoryService adoptionHistoryService, IUserService userService) : base(userService)
        {
            _adoptionHistoryService = adoptionHistoryService;
        }

        [Authorize]
        [HttpGet("{animalId:guid}")]
        public async Task<ActionResult<RequestResponse<PagedResponse<AdoptionHistoryDTO>>>> GetAdoptionHistoriesByAnimal([FromQuery] PaginationSearchQueryParams pagination, [FromRoute] Guid animalId)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _adoptionHistoryService.GetAdoptionHistoriesByAnimal(pagination, animalId)) :
                this.ErrorMessageResult<PagedResponse<AdoptionHistoryDTO>>(currentUser.Error);
        }

        [Authorize]
        [HttpGet("{userId:guid}")]
        public async Task<ActionResult<RequestResponse<PagedResponse<AdoptionHistoryDTO>>>> GetAdoptionHistoriesByUser([FromQuery] PaginationSearchQueryParams pagination, [FromRoute]Guid userId)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _adoptionHistoryService.GetAdoptionHistoriesByUser(pagination, userId)) :
                this.ErrorMessageResult<PagedResponse<AdoptionHistoryDTO>>(currentUser.Error);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<RequestResponse>> Add([FromBody] AdoptionHistoryDTO adoptionHistory)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _adoptionHistoryService.AddAdoptionHistory(adoptionHistory, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }

    }

}
