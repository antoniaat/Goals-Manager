using GoalsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalsManager.Data
{
    public class DbInitializer
    {
        public static void Initialize(GoalsManagerContext context)
        {
            context.Database.EnsureCreated();
            if (context.Goals.Any())
            {
                return;
            }

            var goals = new List<Goals>()
            {
                new Goals{ Id=Guid.NewGuid(), Name="Read 50 books", Description="Read 50 books of different types in 2020 year.", Start=new DateTime(14/10/2002), End=new DateTime(14/10/2003), Finished=false, Progress="20%" }
            };

            var yearlyGoals = new YearlyGoals{ Id=Guid.NewGuid(), Name="2020 Goals", Goals= goals};

            foreach(Goals goal in goals)
            {
                context.Goals.Add(goal);
            }

            context.SaveChanges();
            context.YearlyGoals.Add(yearlyGoals);
        }
    }
}
