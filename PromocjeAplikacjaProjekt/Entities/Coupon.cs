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
    [Table("Coupon", Schema = "Bookstore")]
    public class Coupon : BaseEntity
    {
        [Required]
        public int Id { get; set; }
        public int MultiplierDiscount { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
