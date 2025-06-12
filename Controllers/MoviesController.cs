using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/movies")]
public class MoviesController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    // ImageURL = "../Images/{name}.{fileExtension}"
    // ImageURL = "./public/Images/{name}.{fileExtension}"
    private List<Movie> movies = new List<Movie>()
    {
        new Movie {Id = 1, Title = "Inception", Type = "Movie", ReleaseYear = 2010, Genre = "Thriller", Director = "Christopher Nolan", ImageURL = "./Images/inception.jpg"},
        new Movie {Id = 2, Title = "Breaking Bad", Type = "TV Show", ReleaseYear = 2008, Genre = "Crime/Drama", Director = "Vince Gillighan", ImageURL = "./Images/breaking_bad.jpg"},
        new Movie {Id = 3, Title = "Fight Club", Type = "Movie", ReleaseYear = 1900, Genre = "Thriller/Crime/Drama", Director = "David Fincher", ImageURL = "./Images/fight.jpg"},
        new Movie {Id = 4, Title = "Twin Peaks", Type = "TV Show", ReleaseYear = 1990, Genre = "Crime/Horror/Mystery/Soap", Director = "David Lynch", ImageURL = "./Images/peaks.jpg"}
    };

    public MoviesController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

        // If our database is currently empty, we can append data here
        if (!_context.Movies.Any())
        {
            _context.Movies.AddRange(movies);
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Movie>> GetAllMovies()
    {
        return Ok(_context.Movies.ToList());
    }

    [HttpGet("cached")]
    public IEnumerable<Movie> GetCached()
    {
        return _context.Movies.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Movie> GetMovieById(int id)
    {
        var movie = _context.Movies.Find(id);

        if (movie != null)
        {
            return Ok(movie);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost("update")]
    public ActionResult<Movie> CreateUsingDTO([FromForm] MovieCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var movie = _mapper.Map<Movie>(dto);
        _context.Movies.Add(movie);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpGet("/imageproxy")]
    private async Task<IActionResult> ProxyImage([FromQuery] string url)
    {
        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            return BadRequest("Invalid URL");
        }

        using var client = new HttpClient();
        var imageBytes = await client.GetByteArrayAsync(url);
        return File(imageBytes, "image/jpeg");
    }

    [HttpPost("{id}/update-image")]
    public IActionResult UpdateImage(int id, [FromBody] MovieUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound();
        }

        movie.ImageURL = dto.ImageURL!.StartsWith("http") ? dto.ImageURL : $"./Images/{dto.ImageURL.Trim()}";
        _context.SaveChanges();

        return Ok(new { message = "Image updated", movie.ImageURL });
    }
}