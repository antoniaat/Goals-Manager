using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;

namespace GoalsManager.Pages.LifeGoalsPage
{
    public class DetailsModel : PageModel
    {
        private readonly GoalsManager.Models.GoalsManagerContext _context;

        public DetailsModel(GoalsManager.Models.GoalsManagerContext context)
        {
            _context = context;
        }

        public LifeGoals LifeGoals { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LifeGoals = await _context.LifeGoals.FirstOrDefaultAsync(m => m.Id == id);

            if (LifeGoals == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
