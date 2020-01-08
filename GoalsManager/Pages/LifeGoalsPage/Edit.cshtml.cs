using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.LifeGoalsPage
{
    public class EditModel : PageModel
    {
        private readonly GoalsManagerContext _context;

        public EditModel(GoalsManagerContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LifeGoals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LifeGoalsExists(LifeGoals.Id))
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

        private bool LifeGoalsExists(Guid id)
        {
            return _context.LifeGoals.Any(e => e.Id == id);
        }
    }
}
