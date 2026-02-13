using System;
using System.ComponentModel.DataAnnotations;

namespace EfTest.DTOs;

public class HashPasswordRequest
{
    [Required]
    public required string Password1 { get; set; }

    [Required]
    public required string Password2 { get; set; }
}
