﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddTagViewModel
    {

        [Required(ErrorMessage="This is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters.")]
        public string Name { get; set; }


        public AddTagViewModel()
        {
        }
    }
}
