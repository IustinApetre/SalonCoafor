using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonCoafor.Data;
using SalonCoafor.Models;

namespace SalonCoafor.Pages.Stylists
{
    public class EditModel : PageModel
    {
        private readonly SalonCoafor.Data.SalonCoaforContext _context;

        public EditModel(SalonCoafor.Data.SalonCoaforContext context)
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

            var stylist =  await _context.Stylist.FirstOrDefaultAsync(m => m.ID == id);
            if (stylist == null)
            {
                return NotFound();
            }
            Stylist = stylist;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Stylist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StylistExists(Stylist.ID))
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

        private bool StylistExists(int id)
        {
          return (_context.Stylist?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
