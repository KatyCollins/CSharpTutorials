using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using Newtonsoft.Json;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;
        private static readonly HttpClient client = new HttpClient();

        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }

        private string _getMovieUrl = "http://localhost:49892/api/Movie/GetMovies?searchString={0}&movieGenre={1}";
        private string _getGenresUrl = "http://localhost:49892/api/Movie/GetGenres";
        private string _getDetailsUrl = "http://localhost:49892/api/Movie/GetDetails/{0}";
        private string _createMovieUrl = "http://localhost:49892/api/Movie/CreateMovie";

        // GET: Movies
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            // Get the list of movies
            // Instantiate the List of movies
            List<Movie> movieList = new List<Movie>();

            // Asyncrhonously call the _getMovieUrl 
            // the {0} and {1} concept of formatting our string url is called string interpolation
            HttpResponseMessage response = await client.GetAsync(string.Format(_getMovieUrl, searchString, movieGenre));

            // If the response is successful (HTTP 2XX)
            if (response.IsSuccessStatusCode)
            {
                // We expect the API to return an array of Movie objects
                var movieArray = await response.Content.ReadAsAsync<Movie[]>();

                // Convert the array of movies returned into a List and assign it to the movieList that we instantiated earlier
                movieList = movieArray.ToList();
            }

            //  GET THE LIST OF GENRES
            // Instantiate the List of genres (string type)
            List<string> genreList = new List<string>();

            // Asychronously call the _getGenresUrl
            response = await client.GetAsync(_getGenresUrl);

            // If the response is successful (HTTP 2XX)
            if (response.IsSuccessStatusCode)
            {
                // We expect the API to return an array of strings
                var genreArray = await response.Content.ReadAsAsync<string[]>();

                // cnovert the array of strings returned into a list and assigned it to the genreList that we instantiated earlier
                genreList = genreArray.ToList();
            }


            // Assign the genreList and movieList generated from the two API calls and return it to the View
            var movieGenreVM = new MovieGenreViewModel();
            movieGenreVM.genres = new SelectList(genreList);
            movieGenreVM.movies = movieList;

            return View(movieGenreVM);

        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Instantiate the Movie object that we want to return to the view
            var movie = new Movie();

            // Call the API using string interpolation to append the id to the end of our URL
            HttpResponseMessage response = await client.GetAsync(string.Format(_getDetailsUrl, id));

            // If the response is successful (HTTP 2XX)
            if (response.IsSuccessStatusCode)
            {
                // We expect the API to return a single Movie object
                movie = await response.Content.ReadAsAsync<Movie>();
            }

            if (movie == null)
            {
                return NotFound();
            }

            // Return the movie to the View
            return View(movie);

        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                // Create the payload by serializing the movie object into JSON to pass to the API
                var payloadJson = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");

                // Call the API at the _createMovieUrl and passing it the JSON payload
                HttpResponseMessage response = await client.PostAsync(_createMovieUrl, payloadJson);

                // If the response is successful (HTTP 2XX)
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(movie);

        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
