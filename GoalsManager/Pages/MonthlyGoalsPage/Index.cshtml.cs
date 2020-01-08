using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.MonthlyGoalsPage
{
    public class IndexModel : PageModel
    {
        private readonly GoalsManagerContext _context;

        public IndexModel(GoalsManagerContext context)
        {
            _context = context;
        }

        public IList<MonthlyGoals> MonthlyGoals { get;set; }

        public async Task OnGetAsync()
        {
            MonthlyGoals = await _context.MonthlyGoals.ToListAsync();
        }
    }
}
