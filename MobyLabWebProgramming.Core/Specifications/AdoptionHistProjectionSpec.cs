using Ardalis.Specification;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class AdoptionHistoryProjectionSpec : BaseSpec<AdoptionHistoryProjectionSpec, AdoptionHistory, AdoptionHistoryDTO>
    {
        protected override Expression<Func<AdoptionHistory, AdoptionHistoryDTO>> Spec => e => new()
        {
            UserId = e.UserId,
            AnimalId = e.AnimalId,
            AdoptionStartDate = e.AdoptionStartDate,
            AdoptionEndDate = e.AdoptionEndDate
        };

        public AdoptionHistoryProjectionSpec() { }

        public AdoptionHistoryProjectionSpec(Guid id) : base(id)
        {
        }

        public AdoptionHistoryProjectionSpec(Guid id, bool byUser)
        {
            if (byUser == true)
            {
                Query.Where(adoptionHistory => adoptionHistory.UserId == id);
            }
            else
            {
                Query.Where(adoptionHistory => adoptionHistory.AnimalId == id);
            }
        }


    }

}
