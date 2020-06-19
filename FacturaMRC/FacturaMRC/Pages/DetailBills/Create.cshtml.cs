using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FacturaMRC.Data;
using FacturacionMRC.Models;

namespace FacturaMRC.Pages.DetailBills
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
        ViewData["BillID"] = new SelectList(_context.Bill, "BillID", "CodeBill");
        ViewData["ProductID"] = new SelectList(_context.Set<Product>(), "ProductID", "Code");
            return Page();
        }

        [BindProperty]
        public DetailBill DetailBill { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DetailBill.Add(DetailBill);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
