using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.LifeGoalsPage
{
    public class IndexModel : PageModel
    {
        private readonly GoalsManagerContext _context;

        public IndexModel(GoalsManagerContext context)
        {
            _context = context;
        }

        public IList<LifeGoals> LifeGoals { get;set; }

        public async Task OnGetAsync()
        {
            LifeGoals = await _context.LifeGoals.ToListAsync();
        }
    }
}
