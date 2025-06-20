using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PromocjeAplikacjaProjekt.Dtos
{
    public class CouponDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int MultiplierDiscount { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
