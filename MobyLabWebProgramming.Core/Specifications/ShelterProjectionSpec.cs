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
    public sealed class ShelterProjectionSpec : BaseSpec<ShelterProjectionSpec, Shelter, ShelterDTO>
    {
        protected override Expression<Func<Shelter, ShelterDTO>> Spec => e => new()
        {
            Id = e.Id,
            Name = e.Name,
            Location = e.Location
        };

        public ShelterProjectionSpec() { }

        public ShelterProjectionSpec(Guid id) : base(id)
        {
        }

        public ShelterProjectionSpec(string? search)
        {
            search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;

            if (search == null)
            {
                return;
            }

            var searchExpr = $"%{search.Replace(" ", "%")}%";

            Query.Where(e => EF.Functions.ILike(e.Name, searchExpr));
        }
    }

}
