using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalonCoafor.Models;

namespace SalonCoafor.Data
{
    public class SalonCoaforContext : DbContext
    {
        public SalonCoaforContext (DbContextOptions<SalonCoaforContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointment { get; set; } = default!;

        public DbSet<Service>? Service { get; set; }

        public DbSet<Stylist>? Stylist { get; set; }

        public DbSet<User>? User { get; set; }
    }
}
