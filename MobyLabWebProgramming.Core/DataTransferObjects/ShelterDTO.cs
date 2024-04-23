using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects
{
    public class ShelterDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
      //  public ICollection<AnimalDTO> Animals { get; set; } = default!;
    }

}
