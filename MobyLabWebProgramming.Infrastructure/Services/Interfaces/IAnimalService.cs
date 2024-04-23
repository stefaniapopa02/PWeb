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
    public interface IAnimalService
    {
        /// <summary>
        /// GetAnimal will provide the information about an animal given its animal Id.
        /// </summary>
        public Task<ServiceResponse<AnimalDTO>> GetAnimal(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// GetAnimals returns a page with animal information from the database.
        /// </summary>
        public Task<ServiceResponse<PagedResponse<AnimalDTO>>> GetAnimals(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);

        /// <summary>
        /// GetAnimalCount returns the number of animals in the database.
        /// </summary>
        public Task<ServiceResponse<int>> GetAnimalCount(CancellationToken cancellationToken = default);

        /// <summary>
        /// AddAnimal adds an animal.
        /// </summary>
        public Task<ServiceResponse> AddAnimal(AnimalDTO animal, UserDTO user, CancellationToken cancellationToken = default);

        /// <summary>
        /// UpdateAnimal updates an animal.
        /// </summary>
        public Task<ServiceResponse> UpdateAnimal(AnimalDTO animal, UserDTO user, CancellationToken cancellationToken = default);

        /// <summary>
        /// DeleteAnimal deletes an animal.
        /// </summary>
        public Task<ServiceResponse> DeleteAnimal(Guid id, UserDTO user, CancellationToken cancellationToken = default);
    }

}
