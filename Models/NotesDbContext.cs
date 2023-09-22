using Microsoft.EntityFrameworkCore;
using NotesAppPr.Models; 

namespace NotesAppPr.Models
{
    public class NotesDbContext : DbContext
    {
        
         public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {

        } 

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    } 

}