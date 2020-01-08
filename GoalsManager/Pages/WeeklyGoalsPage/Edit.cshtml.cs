using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.WeeklyGoalsPage
{
    public class EditModel : PageModel
    {
        private readonly GoalsManagerContext _context;

        public EditModel(GoalsManagerContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WeeklyGoals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeeklyGoalsExists(WeeklyGoals.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WeeklyGoalsExists(Guid id)
        {
            return _context.WeeklyGoals.Any(e => e.Id == id);
        }
    }
}
