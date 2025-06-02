public class Movie
{
    /// <summary>
    /// DB Primary key
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Title of the movie/tv-show
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// Either a movie or a TV show
    /// </summary>
    public string? Type { get; set; }
    public int ReleaseYear { get; set; }
    public string? Genre { get; set; }
    public string? Director { get; set; }

    public string? ImageURL { get; set; }
}