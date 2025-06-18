using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/testing/movies")]
public class MemoryOnlyMovieController : ControllerBase
{
    private List<Movie> movies = new List<Movie>()
    {
        new Movie {Id = 1, Title = "Inception", Type = "Movie", ReleaseYear = 2010, Genre = "Thriller", Director = "Christopher Nolan", ImageURL = "./Images/inception.jpg"},
        new Movie {Id = 2, Title = "Breaking Bad", Type = "TV Show", ReleaseYear = 2008, Genre = "Crime/Drama", Director = "Vince Gillighan", ImageURL = "./Images/breaking_bad.jpg"},
        new Movie {Id = 3, Title = "Fight Club", Type = "Movie", ReleaseYear = 1900, Genre = "Thriller/Crime/Drama", Director = "David Fincher", ImageURL = "./Images/fight.jpg"},
        new Movie {Id = 4, Title = "Twin Peaks", Type = "TV Show", ReleaseYear = 1990, Genre = "Crime/Horror/Mystery/Soap", Director = "David Lynch", ImageURL = "./Images/peaks.jpg"},
        new Movie {Id = 5, Title = "Star Trek: The Original Series", Type = "TV Show", ReleaseYear = 1966, Genre = "Sci-fi", Director = "Gene Roddenberry", ImageURL = "./Images/trek.jpg"},
        new Movie {Id = 6, Title = "Star Wars: Episode IV - A New Hope", Type = "Movie", ReleaseYear = 1977, Genre = "Sci-fi", Director = "George Lucas", ImageURL ="./Images/wars.jpg"}
    };

    [HttpGet]
    public ActionResult<IEnumerable<Movie>> GetAllMovies()
    {
        return Ok(movies.ToList());
    }
}