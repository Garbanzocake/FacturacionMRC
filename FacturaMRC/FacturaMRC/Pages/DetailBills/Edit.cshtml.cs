using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacturaMRC.Data;
using FacturacionMRC.Models;

namespace FacturaMRC.Pages.DetailBills
{
    public class EditModel : PageModel
    {
        private readonly FacturaMRC.Data.FacturaMRCContext _context;

        public EditModel(FacturaMRC.Data.FacturaMRCContext context)
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
           ViewData["BillID"] = new SelectList(_context.Bill, "BillID", "CodeBill");
           ViewData["ProductID"] = new SelectList(_context.Set<Product>(), "ProductID", "Code");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DetailBill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailBillExists(DetailBill.DetailBillID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DetailBillExists(int id)
        {
            return _context.DetailBill.Any(e => e.DetailBillID == id);
        }
    }
}
