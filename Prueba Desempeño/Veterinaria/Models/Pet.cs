using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Specie { get; set; }
        public string? Race { get; set; }
        public DateTime DateBrith { get; set; }
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public string? Phote { get; set; }
        public Owner? Owner { get; set; }
        public ICollection<Quote>? Quotes { get; set; }

    }
}