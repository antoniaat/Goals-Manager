using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoalsManager.Models
{
    public class YearlyGoals
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(80)]
        [MinLength(2)]
        public string Name { get; set; }

        [MaxLength(80)]
        [MinLength(2)]
        public string Description { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public bool Finished { get; set; }

        public string Progress { get; set; }
    }
}
