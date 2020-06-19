using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacturacionMRC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FacturacionMRC.Pages.Consultas
{
    public class IndexModel : PageModel
    {

        private readonly FacturaMRC.Data.FacturaMRCContext _context;

        public IndexModel(FacturaMRC.Data.FacturaMRCContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; }


        public async Task OnGetAsync()
        {
            Product = await _context.Product
                .Where(p => p.Stock <= 5)
                .Include(p => p.TypeProduct)
                .Include(p => p.Brand).ToListAsync();
            
            
        }

      
    }
}