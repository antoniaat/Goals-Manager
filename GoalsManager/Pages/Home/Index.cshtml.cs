using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly GoalsManagerContext _context;

        public IndexModel(GoalsManagerContext context)
        {
            _context = context;
        }

        public IList<Goals> Goals { get;set; }

        public async Task OnGetAsync()
        {
            Goals = await _context.Goals.ToListAsync();
        }
    }
}
