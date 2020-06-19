using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacturaMRC.Data;
using FacturacionMRC.Models;

namespace FacturaMRC.Pages.Ivas
{
    public class DetailsModel : PageModel
    {
        private readonly FacturaMRC.Data.FacturaMRCContext _context;

        public DetailsModel(FacturaMRC.Data.FacturaMRCContext context)
        {
            _context = context;
        }

        public Iva Iva { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Iva = await _context.Iva.FirstOrDefaultAsync(m => m.IvaID == id);

            if (Iva == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
