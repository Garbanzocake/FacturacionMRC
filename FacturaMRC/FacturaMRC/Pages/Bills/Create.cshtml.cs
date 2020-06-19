using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FacturaMRC.Data;
using FacturacionMRC.Models;

namespace FacturaMRC.Pages.Bills
{
    public class CreateModel : PageModel
    {
        private readonly FacturaMRC.Data.FacturaMRCContext _context;

        public CreateModel(FacturaMRC.Data.FacturaMRCContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "IdCard");
        ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "IdCard");
            return Page();
        }

        [BindProperty]
        public Bill Bill { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bill.Add(Bill);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
