using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.Home
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
            DbInitializer.Initialize(_context);

            return Page();
        }

        [BindProperty]
        public Goals Goals { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Goals.Add(Goals);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}