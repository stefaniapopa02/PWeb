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
    public class AdoptionHistoryService : IAdoptionHistoryService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;

        /// <summary>
        /// Inject the required repository through the constructor.
        /// </summary>
        public AdoptionHistoryService(IRepository<WebAppDatabaseContext> repository)
        {
            _repository = repository;
        }


        public async Task<ServiceResponse<PagedResponse<AdoptionHistoryDTO>>> GetAdoptionHistoriesByUser(PaginationSearchQueryParams pagination, Guid userId, CancellationToken cancellationToken = default)
        {
            var result = await _repository.PageAsync(pagination, new AdoptionHistoryProjectionSpec(userId, true), cancellationToken);

            return ServiceResponse<PagedResponse<AdoptionHistoryDTO>>.ForSuccess(result);
        }

        public async Task<ServiceResponse<PagedResponse<AdoptionHistoryDTO>>> GetAdoptionHistoriesByAnimal(PaginationSearchQueryParams pagination, Guid animalId,CancellationToken cancellationToken = default)
        {
            var result = await _repository.PageAsync(pagination, new AdoptionHistoryProjectionSpec(animalId, false), cancellationToken);

            return ServiceResponse<PagedResponse<AdoptionHistoryDTO>>.ForSuccess(result);
        }



        public async Task<ServiceResponse<int>> GetAdoptionHistoryCount(CancellationToken cancellationToken = default) =>
            ServiceResponse<int>.ForSuccess(await _repository.GetCountAsync<AdoptionHistory>(cancellationToken));

        public async Task<ServiceResponse> AddAdoptionHistory(AdoptionHistoryDTO adoptionHistory, UserDTO user, CancellationToken cancellationToken = default)
        {

            await _repository.AddAsync(new AdoptionHistory
            {
                UserId = adoptionHistory.UserId,
                AnimalId = adoptionHistory.AnimalId,
                AdoptionEndDate = adoptionHistory.AdoptionEndDate,
                AdoptionStartDate = adoptionHistory.AdoptionStartDate,
            }, cancellationToken);

            return ServiceResponse.ForSuccess();
        }

    }
}
