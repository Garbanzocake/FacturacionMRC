using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionMRC.Models
{
    public class Bill
    {
        //Properties Definition

        [Key]
        public int BillID { get; set; }

        [Display(Name = "Código")]
        [StringLength(15, MinimumLength = 5)]
        [Required]
        public string CodeBill { get; set; }

        [Display(Name = "Código Empleado")]
        [Required]
        public int EmployeeID { get; set; }

        [Display(Name = "Código Cliente")]
        [Required]
        public int CustomerID { get; set; }

        [Display(Name = "Fecha de Emisión")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        //Navigation Properties Definition

        public Employee Employee { get; set; }

        public Customer Customer { get; set; }

        public ICollection<DetailBill> DetailBills { get; set; }
    }
}
