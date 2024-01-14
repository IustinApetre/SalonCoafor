using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalonCoafor.Data;
using SalonCoafor.Models;

namespace SalonCoafor.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly SalonCoafor.Data.SalonCoaforContext _context;

        public IndexModel(SalonCoafor.Data.SalonCoaforContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Service != null)
            {
                Service = await _context.Service.ToListAsync();
            }
        }
    }
}
