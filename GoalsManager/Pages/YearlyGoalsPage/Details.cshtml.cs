using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;

namespace GoalsManager.Pages.YearlyGoalsPage
{
    public class DetailsModel : PageModel
    {
        private readonly GoalsManager.Models.GoalsManagerContext _context;

        public DetailsModel(GoalsManager.Models.GoalsManagerContext context)
        {
            _context = context;
        }

        public YearlyGoals YearlyGoals { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            YearlyGoals = await _context.YearlyGoals.FirstOrDefaultAsync(m => m.Id == id);

            if (YearlyGoals == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
