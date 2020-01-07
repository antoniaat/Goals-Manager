using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;

namespace GoalsManager.Pages.WeeklyGoalsPage
{
    public class IndexModel : PageModel
    {
        private readonly GoalsManager.Models.GoalsManagerContext _context;

        public IndexModel(GoalsManager.Models.GoalsManagerContext context)
        {
            _context = context;
        }

        public IList<WeeklyGoals> WeeklyGoals { get;set; }

        public async Task OnGetAsync()
        {
            WeeklyGoals = await _context.WeeklyGoals.ToListAsync();
        }
    }
}
