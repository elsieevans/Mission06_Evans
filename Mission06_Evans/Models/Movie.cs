using System.ComponentModel.DataAnnotations;

namespace Mission06_Evans.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; } // Primary Key
    [Required]
    public string Category { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string Rating { get; set; } // G, PG, PG-13, R
    public bool? Edited { get; set; } // Optional
    public string? LentTo { get; set; } // Optional
    [MaxLength(25)]
    public string? Notes { get; set; } // Optional, max 25 chars
}