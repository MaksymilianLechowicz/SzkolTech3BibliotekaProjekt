using System.ComponentModel.DataAnnotations;

namespace CzytelnikAplikacjaProjekt.Dtos
{
    public class ReaderDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
