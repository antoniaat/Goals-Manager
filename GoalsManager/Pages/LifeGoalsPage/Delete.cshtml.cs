using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.LifeGoalsPage
{
    public class DeleteModel : PageModel
    {
        private readonly GoalsManagerContext _context;

        public DeleteModel(GoalsManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LifeGoals = await _context.LifeGoals.FindAsync(id);

            if (LifeGoals != null)
            {
                _context.LifeGoals.Remove(LifeGoals);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
