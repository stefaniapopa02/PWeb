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
    public interface IShelterService
    {
        /// <summary>
        /// GetShelter will provide the information about a shelter given its shelter Id.
        /// </summary>
        public Task<ServiceResponse<ShelterDTO>> GetShelter(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// GetShelters returns a page with shelter information from the database.
        /// </summary>
        public Task<ServiceResponse<PagedResponse<ShelterDTO>>> GetShelters(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);

        /// <summary>
        /// GetShelterCount returns the number of shelters in the database.
        /// </summary>
        public Task<ServiceResponse<int>> GetShelterCount(CancellationToken cancellationToken = default);

        /// <summary>
        /// AddShelter adds a shelter.
        /// </summary>
        public Task<ServiceResponse> AddShelter(ShelterDTO shelter, UserDTO user, CancellationToken cancellationToken = default);


        Task<ServiceResponse> AddBreedToShelter(Guid shelterId, Guid breedId);
        Task<ServiceResponse> RemoveBreedFromShelter(Guid shelterId, Guid breedId);


        /// <summary>
        /// UpdateShelter updates a shelter.
        /// </summary>
        public Task<ServiceResponse> UpdateShelter(ShelterDTO shelter, UserDTO user, CancellationToken cancellationToken = default);

        /// <summary>
        /// DeleteShelter deletes a shelter.
        /// </summary>
        public Task<ServiceResponse> DeleteShelter(Guid id, UserDTO user, CancellationToken cancellationToken = default);
    }

}
