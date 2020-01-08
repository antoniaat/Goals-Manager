using GoalsManager.Areas.Identity.Data;
using GoalsManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoalsManager.Data
{
    public class GoalsManagerContext : IdentityDbContext<GoalsManagerUser>
    {
        public GoalsManagerContext(DbContextOptions<GoalsManagerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Goals> Goals { get; set; }

        public DbSet<LifeGoals> LifeGoals { get; set; }

        public DbSet<MonthlyGoals> MonthlyGoals { get; set; }

        public DbSet<YearlyGoals> YearlyGoals { get; set; }

        public DbSet<WeeklyGoals> WeeklyGoals { get; set; }
    }
}
