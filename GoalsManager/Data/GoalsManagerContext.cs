using Microsoft.EntityFrameworkCore;

namespace GoalsManager.Models
{
    public class GoalsManagerContext : DbContext
    {
        public GoalsManagerContext (DbContextOptions<GoalsManagerContext> options)
            : base(options)
        {
        }

        public DbSet<GoalsManager.Models.Goals> Goals { get; set; }

        public DbSet<GoalsManager.Models.LifeGoals> LifeGoals { get; set; }

        public DbSet<GoalsManager.Models.MonthlyGoals> MonthlyGoals { get; set; }

        public DbSet<GoalsManager.Models.YearlyGoals> YearlyGoals { get; set; }

        public DbSet<GoalsManager.Models.WeeklyGoals> WeeklyGoals { get; set; }
    }
}
