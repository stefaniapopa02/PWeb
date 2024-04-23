using Ardalis.Specification;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class ProfileProjectionSpec : BaseSpec<ProfileProjectionSpec, Profile, ProfileDTO>
    {
        protected override Expression<Func<Profile, ProfileDTO>> Spec => e => new()
        {
          //  Id = e.Id,
            Address = e.Address,
            ImageUrl = e.ImageUrl,
            Description = e.Description,
            UserId = e.UserId,
        };

        public ProfileProjectionSpec() { }

        public ProfileProjectionSpec(Guid userId)
        {

            Query.Select(Derived.Spec).Where(item => item.UserId == userId);
        }

    }
}
