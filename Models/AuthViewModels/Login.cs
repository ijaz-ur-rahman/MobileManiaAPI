﻿using Microsoft.Build.Framework;

namespace MobileManiaAPI.Models.AuthViewModels
{
    public class Login
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
