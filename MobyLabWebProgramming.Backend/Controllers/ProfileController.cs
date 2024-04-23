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
    public class ProfileController : AuthorizedController
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService, IUserService userService) : base(userService)
        {
            _profileService = profileService;
        }

        [Authorize]
        [HttpGet("{userId:guid}")]
        public async Task<ActionResult<RequestResponse<ProfileDTO>>> GetByUserId([FromRoute] Guid userId)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _profileService.GetProfile(userId)) :
                this.ErrorMessageResult<ProfileDTO>(currentUser.Error);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<RequestResponse<PagedResponse<ProfileDTO>>>> GetPage([FromQuery] PaginationSearchQueryParams pagination)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _profileService.GetProfiles(pagination)) :
                this.ErrorMessageResult<PagedResponse<ProfileDTO>>(currentUser.Error);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<RequestResponse>> Add([FromBody] ProfileDTO profile)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _profileService.AddProfile(profile, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<RequestResponse>> Update([FromBody] ProfileDTO profile)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _profileService.UpdateProfile(profile, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<RequestResponse>> Delete([FromRoute] Guid id)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _profileService.DeleteProfile(id, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }
    }
}
