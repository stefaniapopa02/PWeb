using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects
{
    public class ProfileDTO
    {
        public Guid Id { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public string Description { get; set; } = default!;

        public Guid UserId { get; set; } = default!;
        
    }

}
