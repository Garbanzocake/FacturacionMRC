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
    public class IndexModel : PageModel
    {
        private readonly FacturaMRC.Data.FacturaMRCContext _context;

        public IndexModel(FacturaMRC.Data.FacturaMRCContext context)
        {
            _context = context;
        }

        public IList<Iva> Iva { get;set; }

        public async Task OnGetAsync()
        {
            Iva = await _context.Iva.ToListAsync();
        }
    }
}
