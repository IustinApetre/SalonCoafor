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
    public class IndexModel : PageModel
    {
        private readonly SalonCoafor.Data.SalonCoaforContext _context;

        public IndexModel(SalonCoafor.Data.SalonCoaforContext context)
        {
            _context = context;
        }

        public IList<Stylist> Stylist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Stylist != null)
            {
                Stylist = await _context.Stylist.ToListAsync();
            }
        }
    }
}
