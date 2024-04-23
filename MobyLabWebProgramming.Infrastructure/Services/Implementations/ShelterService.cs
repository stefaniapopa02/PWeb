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
    public class ShelterService : IShelterService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;

        /// <summary>
        /// Inject the required repository through the constructor.
        /// </summary>
        public ShelterService(IRepository<WebAppDatabaseContext> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<ShelterDTO>> GetShelter(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAsync(new ShelterProjectionSpec(id), cancellationToken);

            return result != null ?
                ServiceResponse<ShelterDTO>.ForSuccess(result) :
                ServiceResponse<ShelterDTO>.FromError(CommonErrors.ShelterNotFound);
        }

        public async Task<ServiceResponse<PagedResponse<ShelterDTO>>> GetShelters(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
        {
            var result = await _repository.PageAsync(pagination, new ShelterProjectionSpec(), cancellationToken);

            return ServiceResponse<PagedResponse<ShelterDTO>>.ForSuccess(result);
        }

        public async Task<ServiceResponse<int>> GetShelterCount(CancellationToken cancellationToken = default) =>
            ServiceResponse<int>.ForSuccess(await _repository.GetCountAsync<Shelter>(cancellationToken));

        public async Task<ServiceResponse> AddShelter(ShelterDTO shelter, UserDTO user, CancellationToken cancellationToken = default)
        {
            if (user != null && user.Role != UserRoleEnum.Admin)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can add shelters!", ErrorCodes.CannotAdd));
            }

            var result = await _repository.GetAsync(new ShelterProjectionSpec(shelter.Name), cancellationToken);

            if (result != null)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "The shelter already exists!", ErrorCodes.UserAlreadyExists));
            }

            await _repository.AddAsync(new Shelter
            {
                Name = shelter.Name,
                Location = shelter.Location
            }, cancellationToken);

            return ServiceResponse.ForSuccess();
        }




   
        public async Task<ServiceResponse> AddBreedToShelter(Guid shelterId, Guid breedId)

        {

            var shelter = await _repository.GetAsync<Shelter>(new ShelterProjectionSpec(shelterId));

            if (shelter == null)

                return ServiceResponse.FromError(CommonErrors.ShelterNotFound);

            var breed = await _repository.GetAsync<Breed>(new BreedProjectionSpec(breedId));

            if (breed == null) 

                return ServiceResponse.FromError(CommonErrors.BreedNotFound);

            shelter.Shelter_Breeds.Add(new Shelter_Breed

            {
                Shelter = shelter,
                ShelterId = shelterId,
                Breed = breed,
                BreedId = breedId

            });

            await _repository.UpdateAsync(shelter);

            return ServiceResponse.ForSuccess();

        }

        public async Task<ServiceResponse> RemoveBreedFromShelter(Guid shelterId, Guid breedId)

        {

            var shelter = await _repository.GetAsync<Shelter>(new ShelterProjectionSpec(shelterId));

            if (shelter == null)

                return ServiceResponse.FromError(CommonErrors.ShelterNotFound);

            var breed = await _repository.GetAsync<Breed>(new BreedProjectionSpec(breedId));

            if (breed == null)

                return ServiceResponse.FromError(CommonErrors.BreedNotFound);

            var shelter_breed = shelter.Shelter_Breeds.FirstOrDefault(i => i.ShelterId == shelterId && i.BreedId == breedId) ;

            if (shelter_breed == null)

                return ServiceResponse.FromError(CommonErrors.BreedNotFound);

            shelter.Shelter_Breeds.Remove(shelter_breed);

            await _repository.UpdateAsync(shelter);

            return ServiceResponse.ForSuccess();

        }




        public async Task<ServiceResponse> UpdateShelter(ShelterDTO shelter, UserDTO user, CancellationToken cancellationToken = default)
        {
            if (user != null && user.Role != UserRoleEnum.Admin)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can update shelters!", ErrorCodes.CannotAdd));
            }

            var entity = await _repository.GetAsync<Shelter>(new ShelterProjectionSpec(shelter.Id), cancellationToken);

            if (entity != null)
            {
                entity.Name = shelter.Name ?? entity.Name;
                entity.Location = shelter.Location ?? entity.Location;

                await _repository.UpdateAsync(entity, cancellationToken);
            }

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> DeleteShelter(Guid id, UserDTO user, CancellationToken cancellationToken = default)
        {
            if (user != null && user.Role != UserRoleEnum.Admin)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can delete shelters!", ErrorCodes.CannotAdd));
            }

            await _repository.DeleteAsync<Shelter>(id, cancellationToken);

            return ServiceResponse.ForSuccess();
        }
    }

}
