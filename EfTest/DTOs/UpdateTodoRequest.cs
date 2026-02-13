using System;


namespace EfTest.DTOs;

public class UpdateTodoRequest
{
    public string? Title { get; set; }
    public bool? Done { get; set; }
}
