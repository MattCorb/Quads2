using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quads.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID=1, CategoryName="Home"},
                new Category { CategoryID=2, CategoryName="School"},
                new Category { CategoryID=3, CategoryName="Work"},
                new Category { CategoryID=4, CategoryName="Church"}
                );

            mb.Entity<Task>().HasData(
                new Task
                {
                    TaskID = 1,
                    TaskName = "Setup",
                    DueDate = "03-02-2022",
                    IsUrgent = true,
                    IsImportant = false,
                    IsCompleted = false,
                    CategoryID = 1
                },
                new Task
                {
                    TaskID = 2,
                    TaskName = "Plan",
                    DueDate = "03-07-2022",
                    IsUrgent = false,
                    IsImportant = false,
                    IsCompleted = true,
                    CategoryID = 2
                },
                new Task
                {
                    TaskID = 3,
                    TaskName = "Phone Calls",
                    DueDate = "03-05-2022",
                    IsUrgent = true,
                    IsImportant = true,
                    IsCompleted = false,
                    CategoryID = 4
                }
                );
        }
    }
}
