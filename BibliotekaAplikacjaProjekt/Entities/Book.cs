using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BibliotekaAplikacjaProjekt.Entities
{
    [Table("Book", Schema = "Bookstore")]
    public class Book : BaseEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string BookTitle { get; set; }
        public string Author {  get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
