﻿using System.ComponentModel.DataAnnotations;

namespace Gateway.Models;

public class AuthUser
{
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}
