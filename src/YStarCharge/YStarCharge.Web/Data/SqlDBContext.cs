using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YStarCharge.Web.Models;
using YStarCharge.Web.Models;

namespace YStarCharge.Web.Data
{
    public class SqlDBContext : DbContext
    {
        public SqlDBContext (DbContextOptions<SqlDBContext> options)
            : base(options)
        {
        }

        public DbSet<Income> Income { get; set; } = default!;
        public DbSet<Expenses> Expenses { get; set; } = default!;
    }
}
