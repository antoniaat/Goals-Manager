using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GoalsManager.Models;

namespace GoalsManager.Pages.WeeklyGoalsPage
{
    public class CreateModel : PageModel
    {
        private readonly GoalsManager.Models.GoalsManagerContext _context;

        public CreateModel(GoalsManager.Models.GoalsManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WeeklyGoals WeeklyGoals { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WeeklyGoals.Add(WeeklyGoals);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}