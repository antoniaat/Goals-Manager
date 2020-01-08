﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.MonthlyGoalsPage
{
    public class DetailsModel : PageModel
    {
        private readonly GoalsManagerContext _context;

        public DetailsModel(GoalsManagerContext context)
        {
            _context = context;
        }

        public MonthlyGoals MonthlyGoals { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MonthlyGoals = await _context.MonthlyGoals.FirstOrDefaultAsync(m => m.Id == id);

            if (MonthlyGoals == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
