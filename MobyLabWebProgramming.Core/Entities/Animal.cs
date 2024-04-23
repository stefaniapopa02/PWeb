using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Animal : BaseEntity
    {
        public string Name { get; set; } = default!;
        public int Age { get; set; } = default!;
        public bool IsAvailable { get; set; } = default!;
        public DateTime AvailableUntil { get; set; } = default!;


        // Relație many-to-one cu Shelter (mai multe animale pot fi în același adăpost)
        public Shelter Shelter { get; set; } = default!;
        public Guid ShelterId { get; set; } = default!;


        // Relație many-to-one cu Breed (un animal poate fi dintr-o anumită rasă)
        public Breed Breed { get; set; } = default!;
        public Guid BreedId { get; set; } = default!;



        // Relație many-to-many cu User prin intermediul AdoptionHistory
        public ICollection<AdoptionHistory> AdoptedByUsers { get; set; } = default!;


    }


}
