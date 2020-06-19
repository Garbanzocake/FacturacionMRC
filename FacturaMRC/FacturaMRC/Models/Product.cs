using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionMRC.Models
{
    public class Product
    {
        //Properties Definition

        [Key]
        public int ProductID { get; set; }

        [Display(Name = "Código")]
        [StringLength(15, MinimumLength = 5)]
        [Required]
        public string Code { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Tipo")]
        [Required]
        public int TypeProductID { get; set; }

        [Display(Name = "Marca")]
        [Required]
        public int BrandID { get; set; }

        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Stock")]
        [Required]
        public int Stock { get; set; }

        [Display(Name = "Fecha de vencimiento")]
        [DataType(DataType.Date)]
        public DateTime ExpiredAt { get; set; }

        //Navigation Properties Definition

        public ICollection<DetailBill> DetailBills { get; set; }

        public Brand Brand { get; set; }

        public TypeProduct TypeProduct { get; set; }

    }
}
