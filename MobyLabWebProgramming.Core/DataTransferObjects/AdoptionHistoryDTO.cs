using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects
{
    public class AdoptionHistoryDTO
    {
        public Guid UserId { get; set; }
        public Guid AnimalId { get; set; }
        public DateTime AdoptionStartDate { get; set; }
        public DateTime AdoptionEndDate { get; set; }
    }

}
