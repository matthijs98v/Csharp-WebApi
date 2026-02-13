using System;
using System.ComponentModel.DataAnnotations;

namespace EfTest.DTOs;

public class CreateTodoRequest
{
    [Required]
    public string? Title { get; set; }
}
