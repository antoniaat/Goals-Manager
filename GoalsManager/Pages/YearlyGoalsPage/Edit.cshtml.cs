using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.YearlyGoalsPage
{
    public class EditModel : PageModel
    {
        private readonly GoalsManagerContext _context;

        public EditModel(GoalsManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(YearlyGoals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearlyGoalsExists(YearlyGoals.Id))
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

        private bool YearlyGoalsExists(Guid id)
        {
            return _context.YearlyGoals.Any(e => e.Id == id);
        }
    }
}
