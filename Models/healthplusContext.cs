using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beapps.healthplus.api.Models
{
    public class healthplusContext: DbContext
    {
            public healthplusContext(DbContextOptions<healthplusContext> options)
                : base(options)
            {
            }

            public DbSet<Remedy> Remedies { get; set; }
    }
}
