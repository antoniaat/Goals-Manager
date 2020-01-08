using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.MonthlyGoalsPage
{
    public class EditModel : PageModel
    {
        private readonly GoalsManagerContext _context;

        public EditModel(GoalsManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MonthlyGoals MonthlyGoals { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MonthlyGoals = await _context.MonthlyGoals.FirstOrDefaultAsync(m => m.Id == id);

            if (MonthlyGoals == null)
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

            _context.Attach(MonthlyGoals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthlyGoalsExists(MonthlyGoals.Id))
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

        private bool MonthlyGoalsExists(Guid id)
        {
            return _context.MonthlyGoals.Any(e => e.Id == id);
        }
    }
}
