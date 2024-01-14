using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalonCoafor.Data;
using SalonCoafor.Models;

namespace SalonCoafor.Pages.Stylists
{
    public class CreateModel : PageModel
    {
        private readonly SalonCoafor.Data.SalonCoaforContext _context;

        public CreateModel(SalonCoafor.Data.SalonCoaforContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Stylist Stylist { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Stylist == null || Stylist == null)
            {
                return Page();
            }

            _context.Stylist.Add(Stylist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
