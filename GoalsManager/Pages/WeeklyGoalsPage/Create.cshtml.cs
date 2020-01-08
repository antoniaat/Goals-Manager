using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.WeeklyGoalsPage
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