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
    public sealed class AnimalProjectionSpec : BaseSpec<AnimalProjectionSpec, Animal, AnimalDTO>
    {
        
        protected override Expression<Func<Animal, AnimalDTO>> Spec => e => new()
        {
            Id = e.Id,
            Name = e.Name,
            Age = e.Age,
            IsAvailable = e.IsAvailable,
            AvailableUntil = e.AvailableUntil,

            ShelterId = e.ShelterId,
            BreedId = e.BreedId,


        };

        public AnimalProjectionSpec() { }

        public AnimalProjectionSpec(Guid id) : base(id)
        {
        }

        public AnimalProjectionSpec(string? search)
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
