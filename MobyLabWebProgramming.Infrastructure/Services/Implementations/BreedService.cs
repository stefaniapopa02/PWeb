using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;
using MobyLabWebProgramming.Core.Errors;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Core.Specifications;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations
{
    public class BreedService : IBreedService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;

        /// <summary>
        /// Inject the required repository through the constructor.
        /// </summary>
        public BreedService(IRepository<WebAppDatabaseContext> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<BreedDTO>> GetBreed(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAsync(new BreedProjectionSpec(id), cancellationToken);

            return result != null ?
                ServiceResponse<BreedDTO>.ForSuccess(result) :
                ServiceResponse<BreedDTO>.FromError(CommonErrors.BreedNotFound);
        }

        public async Task<ServiceResponse<PagedResponse<BreedDTO>>> GetBreeds(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
        {
            var result = await _repository.PageAsync(pagination, new BreedProjectionSpec(), cancellationToken);

            return ServiceResponse<PagedResponse<BreedDTO>>.ForSuccess(result);
        }

        public async Task<ServiceResponse<int>> GetBreedCount(CancellationToken cancellationToken = default) =>
            ServiceResponse<int>.ForSuccess(await _repository.GetCountAsync<Breed>(cancellationToken));

        public async Task<ServiceResponse> AddBreed(BreedDTO breed, UserDTO user, CancellationToken cancellationToken = default)
        {
            if (user != null && user.Role != UserRoleEnum.Admin) 
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can add breeds!", ErrorCodes.CannotAdd));
            }

            var result = await _repository.GetAsync(new BreedProjectionSpec(breed.Name), cancellationToken);

            if (result != null)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "The breed already exists!", ErrorCodes.UserAlreadyExists));
            }

            await _repository.AddAsync(new Breed
            {
                Name = breed.Name
            }, cancellationToken);

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> UpdateBreed(BreedDTO breed, UserDTO user, CancellationToken cancellationToken = default)
        {
            if (user != null && user.Role != UserRoleEnum.Admin)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can update breeds!", ErrorCodes.CannotAdd));
            }

            var entity = await _repository.GetAsync<Breed>(new BreedProjectionSpec(breed.Id), cancellationToken);

            if (entity != null)
            {
                entity.Name = breed.Name ?? entity.Name;

                await _repository.UpdateAsync(entity, cancellationToken);
            }

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> DeleteBreed(Guid id, UserDTO user, CancellationToken cancellationToken = default)
        {
            if (user != null && user.Role != UserRoleEnum.Admin)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can delete breeds!", ErrorCodes.CannotAdd));
            }

            await _repository.DeleteAsync<Breed>(id, cancellationToken);

            return ServiceResponse.ForSuccess();
        }
    }

}
