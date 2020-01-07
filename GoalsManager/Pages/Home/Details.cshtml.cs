using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;

namespace GoalsManager.Pages.Home
{
    public class DetailsModel : PageModel
    {
        private readonly GoalsManager.Models.GoalsManagerContext _context;

        public DetailsModel(GoalsManager.Models.GoalsManagerContext context)
        {
            _context = context;
        }

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
    }
}
