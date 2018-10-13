using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FAADroneRegistrationApplication.Models;

namespace FAADroneRegistrationApplication.Models
{
    public class FAADroneRegistrationApplicationContext : DbContext
    {
        public FAADroneRegistrationApplicationContext (DbContextOptions<FAADroneRegistrationApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<FAADroneRegistrationApplication.Models.Users> Users { get; set; }

        public DbSet<FAADroneRegistrationApplication.Models.ConsumerDrones> ConsumerDrones { get; set; }

        public DbSet<FAADroneRegistrationApplication.Models.AdministrativeUsers> AdministrativeUsers { get; set; }


    }
}
