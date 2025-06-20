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
    [Table("Order", Schema = "Bookstore")]
    public class Order : BaseEntity
    {
        [Required]
        public int Id { get; set; }
        
        public int BuyerId { get; set; }
        public int Discount { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
