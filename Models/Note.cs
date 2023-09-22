using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NotesAppPr.Models
{
public class Note
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    
    public string? Content { get; set; }

    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}