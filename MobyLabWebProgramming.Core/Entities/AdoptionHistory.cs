using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Entities
{
    public class AdoptionHistory : BaseEntity
    {
        // Cheia primară compusă
        public Guid UserId { get; set; }
        public Guid AnimalId { get; set; }
        public DateTime AdoptionStartDate { get; set; }
        public DateTime AdoptionEndDate { get; set; }


        // Navigational properties
        public User User { get; set; } = default!;
        public Animal Animal { get; set; } = default!;
    }

}
