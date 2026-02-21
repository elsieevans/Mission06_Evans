using System.ComponentModel.DataAnnotations;

namespace Mission06_Evans.Models;

public class Movie
{
    // // Primary key for each movie record
    [Key]
    public int MovieId { get; set; }

    // // Foreign key that connects the movie to a category
    [Required]
    public int CategoryId { get; set; }

    // // Title is required so a movie cannot be added without a name
    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; } = "";

    // // Year is required and must be 1888 or later (first movie year)
    [Required(ErrorMessage = "Year is required.")]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; }

    // // Director is optional, so it can be left blank
    public string? Director { get; set; }

    // // Movie rating (G, PG, etc.) is optional
    public string? Rating { get; set; }

    // // Required field to indicate if the movie was edited
    [Required(ErrorMessage = "Please select if the movie was edited.")]
    public bool Edited { get; set; }

    // // Optional field for who the movie is lent to
    public string? LentTo { get; set; }

    // // Required field to indicate if the movie was copied to Plex
    [Required(ErrorMessage = "Please select if the movie was copied to Plex.")]
    public bool CopiedToPlex { get; set; }

    // // Notes are optional but limited to 25 characters
    [MaxLength(25)]
    public string? Notes { get; set; }
}