using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Shelter_Breed
    {
        public Shelter Shelter { get; set; } = default!;

        public Guid ShelterId { get; set; } = default!;

        public Breed Breed { get; set; } = default!;

        public Guid BreedId { get; set; } = default!;
    }
}
