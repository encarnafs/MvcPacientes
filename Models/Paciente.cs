using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPacientes.Models
{
    public class Paciente
    {
        public int Id { get; set; }


        [StringLength(20, MinimumLength = 2)]
        [Required]
        public string? Name { get; set; }


        [StringLength(40, MinimumLength = 3)]
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(5)]
        public string? Gender { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }


        [DataType(DataType.EmailAddress)]
        [StringLength(40)]
        public string? Email { get; set; }


        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(100)]
        public string? Observaciones { get; set; }


        [RegularExpression(@"^[0-9]+[a-zA-Z0-9""-'\s-]*$")]
        [StringLength(10)]
        [Required]
        public string? Rating { get; set; }
    }
}
