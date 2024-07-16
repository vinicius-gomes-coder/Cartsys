using System.ComponentModel.DataAnnotations;

namespace CartSysAPI.Data.DTO
{
    public class PersonDTO
    {
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? Age { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
    }
}
