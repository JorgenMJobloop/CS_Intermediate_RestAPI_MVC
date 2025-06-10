using System.ComponentModel.DataAnnotations;
public class MovieCreateDto
{
    [Required]
    [StringLength(100)]
    public string? Title { get; set; }
    [Required]
    [RegularExpression("Movie|TV Show")]
    public string? Type { get; set; }
    [Range(1800, 2045)]
    public int ReleaseYear { get; set; }
    [Required]
    public string? Genre { get; set; }
    [Required]
    public string? Director { get; set; }
    [Url]
    public string? ImageURL { get; set; }
}