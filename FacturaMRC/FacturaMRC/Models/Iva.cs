using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionMRC.Models
{
    public class Iva
    {
        //Properties Definition
        [Key]
        public int IvaID { get; set; }

        [Display(Name = "Valor")]
        [StringLength(15, MinimumLength = 2)]
        [Required]
        public string Value { get; set; }

        [Display(Name = "Descripcion")]
        [StringLength(15, MinimumLength = 5)]
        [Required]
        public string Description { get; set; }

        //Navigation Properties Definition
        public ICollection<TypeProduct> TypeProducts { get; set; }
    }
}
