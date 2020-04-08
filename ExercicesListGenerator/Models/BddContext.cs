using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ExercicesListGenerator.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Exo> Exos { get; set; }
        public DbSet<Entrainement> Entrainements { get; set; }

    }
}