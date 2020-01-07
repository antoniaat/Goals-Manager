using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoalsManager.Models
{
    public class LifeGoals
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public ICollection<Goals> Goals { get; set; }
    }
}
