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
    public interface IBreedService
    {

        /// GetBreed will provide the information about a breed given its breed Id.
        public Task<ServiceResponse<BreedDTO>> GetBreed(Guid id, CancellationToken cancellationToken = default);


        /// GetBreeds returns a page with breed information from the database.
        public Task<ServiceResponse<PagedResponse<BreedDTO>>> GetBreeds(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);


        /// GetBreedCount returns the number of breeds in the database.
        public Task<ServiceResponse<int>> GetBreedCount(CancellationToken cancellationToken = default);


        /// AddBreed adds a breed.
        public Task<ServiceResponse> AddBreed(BreedDTO breed, UserDTO user, CancellationToken cancellationToken = default);


        /// UpdateBreed updates a breed.
        public Task<ServiceResponse> UpdateBreed(BreedDTO breed, UserDTO user, CancellationToken cancellationToken = default);


        /// DeleteBreed deletes a breed.
        public Task<ServiceResponse> DeleteBreed(Guid id, UserDTO user, CancellationToken cancellationToken = default);
    }

}
