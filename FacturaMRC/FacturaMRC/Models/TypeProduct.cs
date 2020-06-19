using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionMRC.Models
{
    public class TypeProduct
    {
        //Properties Definition

        [Key]
        public int TypeProductID { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(60, MinimumLength = 10)]
        [Required]
        public string Description { get; set; }

        public int IvaID { get; set; }

        //Navigation Properties Definition

        public ICollection<Product> Products { get; set; }
        
        public Iva Iva { get; set; }

    }
}
