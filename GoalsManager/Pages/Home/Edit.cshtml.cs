using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;

namespace GoalsManager.Pages.Home
{
    public class EditModel : PageModel
    {
        private readonly GoalsManager.Models.GoalsManagerContext _context;

        public EditModel(GoalsManager.Models.GoalsManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Goals Goals { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Goals = await _context.Goals.FirstOrDefaultAsync(m => m.Id == id);

            if (Goals == null)
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

            _context.Attach(Goals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalsExists(Goals.Id))
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

        private bool GoalsExists(Guid id)
        {
            return _context.Goals.Any(e => e.Id == id);
        }
    }
}
