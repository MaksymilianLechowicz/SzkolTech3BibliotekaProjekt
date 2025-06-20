using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PromocjeAplikacjaProjekt.Dtos
{
    public class PointDto
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
