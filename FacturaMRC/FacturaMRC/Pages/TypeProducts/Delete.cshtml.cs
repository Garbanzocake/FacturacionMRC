﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacturaMRC.Data;
using FacturacionMRC.Models;

namespace FacturaMRC.Pages.TypeProducts
{
    public class DeleteModel : PageModel
    {
        private readonly FacturaMRC.Data.FacturaMRCContext _context;

        public DeleteModel(FacturaMRC.Data.FacturaMRCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TypeProduct TypeProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypeProduct = await _context.TypeProduct
                .Include(t => t.Iva).FirstOrDefaultAsync(m => m.TypeProductID == id);

            if (TypeProduct == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypeProduct = await _context.TypeProduct.FindAsync(id);

            if (TypeProduct != null)
            {
                _context.TypeProduct.Remove(TypeProduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
