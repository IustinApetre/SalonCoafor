using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalonCoafor.Data;
using SalonCoafor.Models;

namespace SalonCoafor.Pages.Appointments
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
            ViewData["StylistID"] = new SelectList(_context.Stylist, "ID", "Name"); // Setați lista de frizerii în ViewBag

            if (ViewData["UserID"] == null)
            {
                var users = _context.User.ToList();
                ViewData["UserID"] = new SelectList(users, "ID", "Name");
            }
            if (ViewData["ServiceID"] == null)
            {
                var services = _context.Service.ToList();
                ViewData["ServiceID"] = new SelectList(services, "ID", "Name");
            }
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Appointment == null || Appointment == null)
            {
                return Page();
            }

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
