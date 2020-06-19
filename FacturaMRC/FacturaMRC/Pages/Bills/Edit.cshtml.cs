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

namespace FacturaMRC.Pages.Bills
{
    public class EditModel : PageModel
    {
        private readonly FacturaMRC.Data.FacturaMRCContext _context;

        public EditModel(FacturaMRC.Data.FacturaMRCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bill Bill { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bill = await _context.Bill
                .Include(b => b.Customer)
                .Include(b => b.Employee).FirstOrDefaultAsync(m => m.BillID == id);

            if (Bill == null)
            {
                return NotFound();
            }
           ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "IdCard");
           ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "IdCard");
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

            _context.Attach(Bill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillExists(Bill.BillID))
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

        private bool BillExists(int id)
        {
            return _context.Bill.Any(e => e.BillID == id);
        }
    }
}
