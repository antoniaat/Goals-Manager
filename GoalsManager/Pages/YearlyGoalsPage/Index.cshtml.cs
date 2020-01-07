﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;

namespace GoalsManager.Pages.YearlyGoalsPage
{
    public class IndexModel : PageModel
    {
        private readonly GoalsManager.Models.GoalsManagerContext _context;

        public IndexModel(GoalsManager.Models.GoalsManagerContext context)
        {
            _context = context;
        }

        public IList<YearlyGoals> YearlyGoals { get;set; }

        public async Task OnGetAsync()
        {
            YearlyGoals = await _context.YearlyGoals.ToListAsync();
        }
    }
}