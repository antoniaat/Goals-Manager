using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.LifeGoalsPage
{
    public class CreateModel : PageModel
    {
        private readonly GoalsManagerContext _context;

        public CreateModel(GoalsManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LifeGoals LifeGoals { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LifeGoals.Add(LifeGoals);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}