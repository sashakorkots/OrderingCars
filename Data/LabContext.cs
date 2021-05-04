using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab.Models;

    public class LabContext : DbContext
    {
        public LabContext (DbContextOptions<LabContext> options)
            : base(options)
        {
        }

        public DbSet<lab.Models.IssuedCar> IssuedCar { get; set; }

        public DbSet<lab.Models.Client> Client { get; set; }

        public DbSet<lab.Models.Car> Car { get; set; }
    }
