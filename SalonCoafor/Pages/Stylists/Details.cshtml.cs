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
    public class DetailsModel : PageModel
    {
        private readonly SalonCoafor.Data.SalonCoaforContext _context;

        public DetailsModel(SalonCoafor.Data.SalonCoaforContext context)
        {
            _context = context;
        }

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
    }
}
