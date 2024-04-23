using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces
{
    public interface IAdoptionHistoryService
    {
        public Task<ServiceResponse<PagedResponse<AdoptionHistoryDTO>>> GetAdoptionHistoriesByAnimal(PaginationSearchQueryParams pagination, Guid animalId, CancellationToken cancellationToken = default);
        public Task<ServiceResponse<int>> GetAdoptionHistoryCount(CancellationToken cancellationToken = default);
        public Task<ServiceResponse> AddAdoptionHistory(AdoptionHistoryDTO adoptionHistory, UserDTO user, CancellationToken cancellationToken = default);
        public Task<ServiceResponse<PagedResponse<AdoptionHistoryDTO>>> GetAdoptionHistoriesByUser(PaginationSearchQueryParams pagination, Guid userId, CancellationToken cancellationToken = default);
    }
}
