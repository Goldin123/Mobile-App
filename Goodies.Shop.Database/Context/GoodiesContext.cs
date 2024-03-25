using Goodies.Shop.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodies.Shop.Database.Context
{
    public class GoodiesContext : DbContext
    {
        public GoodiesContext(DbContextOptions<GoodiesContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}
