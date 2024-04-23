using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Profile : BaseEntity
    {
        public string Address { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public string Description { get; set; } = default!;

        public User User { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
    }

}
