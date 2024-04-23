using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Shelter : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Location { get; set; } = default!;

        // Relație one-to-many cu Animal (un adăpost poate găzdui mai multe animale)
        public ICollection<Animal> Animals { get; set; } = default!;

        //Relatie mant-to-many cu Breed

        public ICollection<Shelter_Breed> Shelter_Breeds { get; set; } = new List<Shelter_Breed>();

        //public virtual ICollection<Shelter_Breed> Shelter_Breeds { get; set; } = new List<Shelter_Breed>();

    }
}
