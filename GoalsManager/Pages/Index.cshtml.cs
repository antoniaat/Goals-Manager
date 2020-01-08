using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoalsManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoalsManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GoalsManagerContext _context;

        public IndexModel(GoalsManagerContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            DbInitializer.Initialize(_context);
        }
    }
}
