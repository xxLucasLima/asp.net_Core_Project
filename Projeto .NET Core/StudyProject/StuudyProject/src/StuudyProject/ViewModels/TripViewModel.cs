
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StuudyProject.ViewModels
{
    public class TripViewModel
    {
        [Required]
        [StringLength(100, MinimumLength =5)]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    }
}