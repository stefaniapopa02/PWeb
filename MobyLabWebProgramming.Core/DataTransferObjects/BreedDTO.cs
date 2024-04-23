using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects
{
    public class BreedDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
      //  public ICollection<AnimalDTO> Animals { get; set; } = default!;
    }

}
