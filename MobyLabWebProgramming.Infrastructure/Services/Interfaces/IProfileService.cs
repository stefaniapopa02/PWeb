using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces
{
    public interface IProfileService
    {
        Task<ServiceResponse<ProfileDTO>> GetProfile(Guid userId, CancellationToken cancellationToken = default);

        Task<ServiceResponse<PagedResponse<ProfileDTO>>> GetProfiles(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);

        Task<ServiceResponse<int>> GetProfileCount(CancellationToken cancellationToken = default);

        Task<ServiceResponse> AddProfile(ProfileDTO profile, UserDTO user, CancellationToken cancellationToken = default);

        Task<ServiceResponse> UpdateProfile(ProfileDTO profile, UserDTO user, CancellationToken cancellationToken = default);

        Task<ServiceResponse> DeleteProfile(Guid id, UserDTO user, CancellationToken cancellationToken = default);
    }
}
