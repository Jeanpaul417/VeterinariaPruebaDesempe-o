using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    public class Quote
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PetId { get; set; }
        [ForeignKey("PetId")]
        public int VetId { get; set; }
        [ForeignKey("VetId")]
        public string? Description { get; set; }
        public Pet? Pet { get; set; }
        public Vet? Vet { get; set; }

    }
}