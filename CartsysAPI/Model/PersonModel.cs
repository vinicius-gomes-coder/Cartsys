using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CartSysAPI.Model.Base;

namespace CartSysAPI.Model
{
    [Table("Persons")]
    public class PersonModel : BaseEntity
    {
        [Column("Name")]
        [Required]
        public string? Name { get; set; }

        [Column("Age")]
        [Required]
        public int? Age { get; set; }

        [Column("Address")]
        public string? Address { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

    }
}
