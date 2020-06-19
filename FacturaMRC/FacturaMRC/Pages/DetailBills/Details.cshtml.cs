using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacturaMRC.Data;
using FacturacionMRC.Models;

namespace FacturaMRC.Pages.DetailBills
{
    public class DetailsModel : PageModel
    {
        private readonly FacturaMRC.Data.FacturaMRCContext _context;

        public DetailsModel(FacturaMRC.Data.FacturaMRCContext context)
        {
            _context = context;
        }

        public DetailBill DetailBill { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DetailBill = await _context.DetailBill
                .Include(d => d.Bill)
                .Include(d => d.Product).FirstOrDefaultAsync(m => m.DetailBillID == id);

            if (DetailBill == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
