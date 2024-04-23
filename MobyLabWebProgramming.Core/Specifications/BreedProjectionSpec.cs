using Ardalis.Specification;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class BreedProjectionSpec : BaseSpec<BreedProjectionSpec, Breed, BreedDTO>
    {
        protected override Expression<Func<Breed, BreedDTO>> Spec => e => new()
        {
            Id = e.Id,
            Name = e.Name
        };

        public BreedProjectionSpec() { }

        public BreedProjectionSpec(Guid id) : base(id)
        {
        }

        public BreedProjectionSpec(string? search)
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
