using System;
using System.ComponentModel.DataAnnotations;

namespace EfTest.Models;

public class TodoModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string? Title { get; set; }

    public bool Done { get; set; }
}
