using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/movies")]
public class MoviesController : ControllerBase
{
    private readonly AppDbContext _context;

    private List<Movie> movies = new List<Movie>()
    {
        new Movie {Id = 1, Title = "Inception", Type = "Movie", ReleaseYear = 2010, Genre = "Thriller", Director = "Christopher Nolan", ImageURL = "http://localhost:5155/Images/inception.jpg"},
        new Movie {Id = 2, Title = "Breaking Bad", Type = "TV Show", ReleaseYear = 2008, Genre = "Crime/Drama", Director = "Vince Gillighan", ImageURL = "http://localhost:5155/Images/breaking_bad.jpg"},
        new Movie {Id = 3, Title = "Fight Club", Type = "Movie", ReleaseYear = 1900, Genre = "Thriller/Crime/Drama", Director = "David Fincher", ImageURL = "http://localhost:5155/Images/fight.jpg"},
        new Movie {Id = 4, Title = "Twin Peaks", Type = "TV Show", ReleaseYear = 1990, Genre = "Crime/Horror/Mystery/Soap", Director = "David Lynch", ImageURL = "http://localhost:5155/Images/peaks.jpg"}
    };

    public MoviesController(AppDbContext context)
    {
        _context = context;

        // If our database is currently empty, we can append data here
        if (!_context.Movies.Any())
        {
            _context.Movies.AddRange(movies);
            _context.SaveChanges();
        }
    }


    [HttpGet]
    public IEnumerable<Movie> GetAllMovies()
    {
        return _context.Movies.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Movie> GetMovieById(int id)
    {
        var movie = movies.FirstOrDefault(mov => mov.Id == id);

        if (movie != null)
        {
            return Ok(movie);
        }
        else
        {
            return NotFound();
        }
    }
}