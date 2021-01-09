using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sasarman_Andra_Proiect1.Models;

namespace Sasarman_Andra_Proiect1.Data
{
    public class Sasarman_Andra_Proiect1Context : DbContext
    {
        public Sasarman_Andra_Proiect1Context (DbContextOptions<Sasarman_Andra_Proiect1Context> options)
            : base(options)
        {
        }

        public DbSet<Sasarman_Andra_Proiect1.Models.Vacanță> Vacanță { get; set; }

        public DbSet<Sasarman_Andra_Proiect1.Models.Hotel> Hotel { get; set; }

        public DbSet<Sasarman_Andra_Proiect1.Models.Category> Category { get; set; }
    }
}
