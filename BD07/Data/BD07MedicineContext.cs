using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BD07.Models;

namespace BD07.Data
{
    public class BD07MedicineContext : DbContext
    {
        public BD07MedicineContext (DbContextOptions<BD07MedicineContext> options)
            : base(options)
        {
        }

        public DbSet<BD07.Models.Medicine> Medicine { get; set; } = default!;
    }
}
