﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly FacturaMRC.Data.FacturaMRCContext _context;

        public DeleteModel(FacturaMRC.Data.FacturaMRCContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DetailBill = await _context.DetailBill.FindAsync(id);

            if (DetailBill != null)
            {
                _context.DetailBill.Remove(DetailBill);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
