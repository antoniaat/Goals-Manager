using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;

namespace GoalsManager.Pages.WeeklyGoalsPage
{
    public class DetailsModel : PageModel
    {
        private readonly GoalsManager.Models.GoalsManagerContext _context;

        public DetailsModel(GoalsManager.Models.GoalsManagerContext context)
        {
            _context = context;
        }

        public WeeklyGoals WeeklyGoals { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WeeklyGoals = await _context.WeeklyGoals.FirstOrDefaultAsync(m => m.Id == id);

            if (WeeklyGoals == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
