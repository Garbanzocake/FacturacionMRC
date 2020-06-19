using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionMRC.Models
{
    public class Customer
    {
        //Properties Definition

        [Key]
        public int CustomerID { get; set; }

        [Display(Name = "Cedula")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Su cedula debe tener mínimo 5 digitos y máximo 15")]
        [Required]
        public string IdCard { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Telefono")]
        [StringLength(12, MinimumLength = 7)]
        [Required]
        public string Phone { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        //Navigation Properties Definition

        public ICollection<Bill> Bills { get; set; }

    }
}
