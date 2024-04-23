using Ardalis.Specification;
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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations
{
    public class AnimalService : IAnimalService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;
        private readonly IShelterService _shelterService;

        /// <summary>
        /// Inject the required repository through the constructor.
        /// </summary>
        public AnimalService(IRepository<WebAppDatabaseContext> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<AnimalDTO>> GetAnimal(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAsync(new AnimalProjectionSpec(id), cancellationToken);

            return result != null ?
                ServiceResponse<AnimalDTO>.ForSuccess(result) :
                ServiceResponse<AnimalDTO>.FromError(CommonErrors.AnimalNotFound);
        }

        public async Task<ServiceResponse<PagedResponse<AnimalDTO>>> GetAnimals(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
        {
            var result = await _repository.PageAsync(pagination, new AnimalProjectionSpec(), cancellationToken);

            return ServiceResponse<PagedResponse<AnimalDTO>>.ForSuccess(result);
        }

        public async Task<ServiceResponse<int>> GetAnimalCount(CancellationToken cancellationToken = default) =>
            ServiceResponse<int>.ForSuccess(await _repository.GetCountAsync<Animal>(cancellationToken));

        public async Task<ServiceResponse> AddAnimal(AnimalDTO animal, UserDTO user, CancellationToken cancellationToken = default)
        {
            // Verificarea rolului utilizatorului pentru a adăuga animale, poți ajusta această logică după nevoile tale
            if (user != null && user.Role != UserRoleEnum.Admin)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can add animals!", ErrorCodes.CannotAdd));
            }
          

            await _repository.AddAsync(new Animal
            {
                Name = animal.Name,
                Age = animal.Age,
                IsAvailable = animal.IsAvailable,
                AvailableUntil = animal.AvailableUntil,
                ShelterId = animal.ShelterId,
                BreedId = animal.BreedId,
        }, cancellationToken);

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> UpdateAnimal(AnimalDTO animal, UserDTO user, CancellationToken cancellationToken = default)
        {
            // Verificarea rolului utilizatorului pentru a actualiza animalele, poți ajusta această logică după nevoile tale
            if (user != null && user.Role != UserRoleEnum.Admin)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can update animals!", ErrorCodes.CannotUpdate));
            }

            var entity = await _repository.GetAsync<Animal>(new AnimalProjectionSpec(animal.Id), cancellationToken);

            if (entity != null)
            {
                entity.Name = animal.Name ?? entity.Name;
                entity.Age = animal.Age;
                entity.IsAvailable = animal.IsAvailable;
                entity.AvailableUntil = animal.AvailableUntil;
                entity.ShelterId = animal.ShelterId;
                entity.BreedId = animal.BreedId;

                await _repository.UpdateAsync(entity, cancellationToken);
            }

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> DeleteAnimal(Guid id, UserDTO user, CancellationToken cancellationToken = default)
        {
            // Verificarea rolului utilizatorului pentru a șterge animalele, poți ajusta această logică după nevoile tale
            if (user != null && user.Role != UserRoleEnum.Admin)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can delete animals!", ErrorCodes.CannotDelete));
            }

            await _repository.DeleteAsync<Animal>(id, cancellationToken);

            return ServiceResponse.ForSuccess();
        }
    }

}
