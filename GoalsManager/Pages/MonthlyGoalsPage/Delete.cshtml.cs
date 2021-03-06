﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.MonthlyGoalsPage
{
    public class DeleteModel : PageModel
    {
        private readonly GoalsManagerContext _context;

        public DeleteModel(GoalsManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MonthlyGoals = await _context.MonthlyGoals.FindAsync(id);

            if (MonthlyGoals != null)
            {
                _context.MonthlyGoals.Remove(MonthlyGoals);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
