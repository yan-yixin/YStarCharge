using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YStarCharge.Web.Models;

namespace YStarCharge.Web.Data
{
    public class SqlDBContext : DbContext
    {
        public SqlDBContext (DbContextOptions<SqlDBContext> options)
            : base(options)
        {
        }

        public DbSet<Income> Incomes { get; set; } = default!;
        public DbSet<Expenses> Expenses { get; set; } = default!;
        public DbSet<UserInfo> UserInfo { get; set; } = default!;
    }
}
