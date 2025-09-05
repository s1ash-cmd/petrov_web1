using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using petrov_web1.Models;

namespace petrov_web1.Data
{
    public class petrov_web1Context : DbContext
    {
        public petrov_web1Context (DbContextOptions<petrov_web1Context> options)
            : base(options)
        {
        }

        public DbSet<petrov_web1.Models.Movie> Movie { get; set; } = default!;
    }
}
