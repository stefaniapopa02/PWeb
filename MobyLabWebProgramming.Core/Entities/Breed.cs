using MobyLabWebProgramming.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Breed : BaseEntity
    {
        public string Name { get; set; } = default!;

        // Relație one-to-many cu Animal (o rasă poate avea mai multe animale)
        public ICollection<Animal> Animals { get; set; } = default!;

        //Relatie many-to-many cu Shelter
        public ICollection<Shelter_Breed> Shelter_Breeds { get; set; } = new List<Shelter_Breed>();
    }

}
