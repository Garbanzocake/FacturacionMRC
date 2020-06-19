using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionMRC.Models
{
    public class Employee
    {

        //Properties Definition

        [Key]
        public int EmployeeID { get; set; }

        [Display(Name = "Cedula")]
        [StringLength(15, MinimumLength = 5)]
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

        [Display(Name = "Nombre de usuario")]
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Username { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Contraseña es requerida")]
        [StringLength(255, ErrorMessage = "Debe estar entre 5 y 255 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [Required(ErrorMessage = "Confirmar contraseña es requerida")]
        [StringLength(255, ErrorMessage = "Debe estar entre 5 y 255 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }



        //Navigation Properties Definition

        public ICollection<Bill> Bills { get; set; }

    }
}
