using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    public class Vet
    {
        [Key]
        public int Id { get; set; }
        public string? Names { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public ICollection<Quote>? Quotes { get; set; }
    }
}