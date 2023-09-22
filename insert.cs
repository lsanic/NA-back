using NotesAppPr.Models;
using System;
using System.Linq;

namespace NotesAppPr.Models
{
    public static class DbSeeder
    {
        public static void SeedData(NotesDbContext dbContext)
        {
            var existingNotes = dbContext.Notes.ToList();
            dbContext.Notes.RemoveRange(existingNotes);
            dbContext.SaveChanges();

            Note n1 = new()
            {
                Title = "Business meeting, Thursday",
                CreatedAt = DateTime.UtcNow
            };

            Note n2 = new()
            {
                Title = "Call mom",
                Content = "About the package",
                CreatedAt = DateTime.UtcNow
            };

            Note n3 = new()
            {
                Title = "Grocery list",
                Content = "Tomatoes, bread, coffee, milk",
                CreatedAt = DateTime.UtcNow
            };

            Note n4 = new()
            {
                Title = "Send a postcard to Anna",
                CreatedAt = DateTime.UtcNow
            };

            Note n5 = new()
            {
                Title = "Todo list",
                Content = "Walk the dog, make the bed, call boss",
                CreatedAt = DateTime.UtcNow
            };

            Note n6 = new()
            {
                Title = "Call the doctor",
                Content = "Ask about your allergies",
                CreatedAt = DateTime.UtcNow
            };

            Note n7 = new()
            {
                Title = "Call dad",
                CreatedAt = DateTime.UtcNow
            };

            dbContext.Notes.Add(n1);
            dbContext.Notes.Add(n2);
            dbContext.Notes.Add(n3);
            dbContext.Notes.Add(n4);
            dbContext.Notes.Add(n5);
            dbContext.Notes.Add(n6);
            dbContext.Notes.Add(n7);

            dbContext.SaveChanges();
        }
    }
}
