using BibliotekaAplikacjaProjekt.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PromocjeAplikacjaProjekt.Entities
{
    [Table("Point", Schema = "Bookstore")]
    public class Point : BaseEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ReaderId { get; set; }
        [Required]
        [MaxLength(100)]
        public int Amount { get; set; }
    }
}
