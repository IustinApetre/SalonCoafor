using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalonCoafor.Data;
using SalonCoafor.Models;

namespace SalonCoafor.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly SalonCoafor.Data.SalonCoaforContext _context;

        public IndexModel(SalonCoafor.Data.SalonCoaforContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; } = default!;
        public string StylistSort { get; set; }
       
        public string ServiceSort { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Appointment != null)
            {
                Appointment = await _context.Appointment
                .Include(a => a.Service)
                .Include(a => a.Stylist)
                .Include(a => a.User).ToListAsync();
            }
        }
    }
}
