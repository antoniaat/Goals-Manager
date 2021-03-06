﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GoalsManager.Models;
using GoalsManager.Data;

namespace GoalsManager.Pages.YearlyGoalsPage
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
        public YearlyGoals YearlyGoals { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.YearlyGoals.Add(YearlyGoals);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}