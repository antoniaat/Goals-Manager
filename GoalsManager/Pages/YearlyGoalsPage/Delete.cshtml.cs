﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.YearlyGoalsPage
{
    public class DeleteModel : PageModel
    {
        private readonly GoalsManagerContext _context;

        public DeleteModel(GoalsManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public YearlyGoals YearlyGoals { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            YearlyGoals = await _context.YearlyGoals.FirstOrDefaultAsync(m => m.Id == id);

            if (YearlyGoals == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            YearlyGoals = await _context.YearlyGoals.FindAsync(id);

            if (YearlyGoals != null)
            {
                _context.YearlyGoals.Remove(YearlyGoals);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
