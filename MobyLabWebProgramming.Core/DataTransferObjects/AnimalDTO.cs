using MobyLabWebProgramming.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects
{
    public class AnimalDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public int Age { get; set; } = default!;
        public bool IsAvailable { get; set; } = default!;
        public DateTime AvailableUntil { get; set; } = default!;


        

        // DTO-uri pentru relațiile entităților
       // public ICollection<AdoptionRequestDTO> AdoptionRequests { get; set; } = default!;
        public Guid ShelterId { get; set; } = default!;
        public Guid BreedId { get; set; } = default!;

        //public ICollection<AdoptionHistoryDTO> AdoptedByUsers { get; set; } = default!;


    }

}
