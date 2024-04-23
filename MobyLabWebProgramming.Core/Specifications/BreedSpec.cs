﻿using Ardalis.Specification;
using MobyLabWebProgramming.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class BreedSpec : BaseSpec<BreedSpec, Breed>
    {
        public BreedSpec(Guid id) : base(id)
        {
        }

        public BreedSpec(string name)
        {
            Query.Where(e => e.Name == name);
        }
    }

}
