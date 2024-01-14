using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalonCoafor.Data;
using SalonCoafor.Models;

namespace SalonCoafor.Pages.Stylists
{
    public class DeleteModel : PageModel
    {
        private readonly SalonCoafor.Data.SalonCoaforContext _context;

        public DeleteModel(SalonCoafor.Data.SalonCoaforContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Stylist Stylist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stylist == null)
            {
                return NotFound();
            }

            var stylist = await _context.Stylist.FirstOrDefaultAsync(m => m.ID == id);

            if (stylist == null)
            {
                return NotFound();
            }
            else 
            {
                Stylist = stylist;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Stylist == null)
            {
                return NotFound();
            }
            var stylist = await _context.Stylist.FindAsync(id);

            if (stylist != null)
            {
                Stylist = stylist;
                _context.Stylist.Remove(Stylist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
