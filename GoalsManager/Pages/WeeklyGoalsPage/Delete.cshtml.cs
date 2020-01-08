using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.WeeklyGoalsPage
{
    public class DeleteModel : PageModel
    {
        private readonly GoalsManagerContext _context;

        public DeleteModel(GoalsManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WeeklyGoals = await _context.WeeklyGoals.FindAsync(id);

            if (WeeklyGoals != null)
            {
                _context.WeeklyGoals.Remove(WeeklyGoals);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
