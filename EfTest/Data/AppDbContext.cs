using System;
using EfTest.Models;
using Microsoft.EntityFrameworkCore;


namespace EfTest.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TodoModel> TodoItems { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    // {
    //     //  options.UseSqlServer("Data Source=localhost;Initial Catalog=TodoList;User ID=sa;Password=Welkom01;Trust Server Certificate=True");
    // }
}
